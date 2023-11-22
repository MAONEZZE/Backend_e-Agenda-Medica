using eAgendaMedica.Dominio.Compartilhado;
using FluentResults;

namespace eAgendaMedica.Api.Controllers.Compartilhado
{
    public abstract class ControladorApiBase<TList, TForm, TVisu, TEntity> : ControllerBase
        where TList : ListarBase<TList>
        where TForm : FormBase<TForm>
        where TVisu : VisualizarBase<TVisu>
        where TEntity : EntidadeBase<TEntity>
    {
        private IMapper _map;
        private IServicoBase<TEntity> _service;

        public ControladorApiBase(IServicoBase<TEntity> service, IMapper map)
        {
            this._map = map;
            this._service = service;
        }

        protected IActionResult ProcessarResposta(Result<TEntity> resultado, TForm registroVM = null)
        {
            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            return Ok(new
            {
                Sucesso = true,
                Dados = registroVM
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(string[]), 500)]
        public virtual async Task<IActionResult> SelecionarTodos()
        {
            var resultado = await _service.SelecionarTodosAsync();

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            List<TList> registrosVM = this._map.Map<List<TList>>(resultado.Value);
            //O que está em parenteses será convertido no que está entre <>

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string[]), 500)]
        public virtual async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var resultado = await _service.SelecionarPorIdAsync(id);

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            TForm registrosVM = this._map.Map<TForm>(resultado.Value);
            //O que está em parenteses será convertido no que está entre <>

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [HttpGet("visualizacao-completa/{id}")] // O {} é para colocar o nome do parametro do metodo. É tipo o :id do angular
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public virtual async Task<IActionResult> SelecionarPorIdCompleto(Guid id)
        {
            var resultado = await _service.SelecionarPorIdAsync(id);

            if (resultado.IsFailed)
            {
                return NotFound(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            TVisu registroVM = this._map.Map<TVisu>(resultado.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = registroVM
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public virtual async Task<IActionResult> Inserir(TForm registroVM)
        {
            TEntity registro = this._map.Map<TEntity>(registroVM);

            var resultado = await _service.InserirAsync(registro);

            return ProcessarResposta(resultado, registroVM);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public virtual async Task<IActionResult> Editar(Guid id, TForm registroVM)
        {
            var resultado = await _service.SelecionarPorIdAsync(id);

            if (resultado.IsFailed)
            {
                return NotFound(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            TEntity registro = this._map.Map(registroVM, resultado.Value);
            #region Porque usar esse outro Map?
            /* Ele pega a referencia do primeiro objeto passado pro ele
                * this._map.Map(valor, referência)
                * 
                * Existem variações de Maps e caso fizesse assim para editar:
                * 
                *    Contato contato = this.map.Map<Contato>(contatoVM);
                * 
                * O entityframework perderia a referencia do objeto de destino,
                * já que se fizar isso é a mesma coisa de instancia um novo objeto
                */
            #endregion

            var resultadoEdicao = await _service.EditarAsync(registro);

            return ProcessarResposta(resultadoEdicao, registroVM);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]//Isso daqui mostra os erros qeu podem retornar do endpoint
        public virtual async Task<IActionResult> Excluir(Guid id)
        {
            var resultado = await _service.SelecionarPorIdAsync(id);

            if (resultado.IsFailed)
            {
                return NotFound(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            var registro = resultado.Value;

            var resultadoExclusao = await _service.ExcluirPorRegistroAsync(registro);

            return ProcessarResposta(resultadoExclusao);
        }
    }
}
