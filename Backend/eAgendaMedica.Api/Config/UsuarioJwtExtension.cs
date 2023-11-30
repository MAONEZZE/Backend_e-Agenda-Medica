using eAgendaMedica.Api.ViewModels.ModuloAutenticacao;
using eAgendaMedica.Dominio.ModuloAutenticacao;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eAgendaMedica.Api.Config
{
    public static class UsuarioJwtExtension
    {
        // JWT - jason web token
        public static TokenViewModel GerarJwt(this Usuario usuario, DateTime dataExpiracao) //Monta o view model
        {
            string token = CriarChaveToken(usuario, dataExpiracao);

            var usuarioTkVM = new UsuarioTokenViewModel(usuario.Id, usuario.Nome, usuario.Email, usuario.UserName);

            var tokenVM = new TokenViewModel
            {
                Chave = token,
                DataExpiração = dataExpiracao,
                Usuario = usuarioTkVM
            };

            return tokenVM;
        }

        private static string CriarChaveToken(Usuario usuario, DateTime dataExpiracao) //Monta a chave
        {
            var tokenHandler = new JwtSecurityTokenHandler();//manipulador de tokens

            var segredo = Encoding.ASCII.GetBytes("SegredoeAgendaMedica");//chave da criptografia está sendo convertida em bytes

            var algoritmo = SecurityAlgorithms.HmacSha256Signature;// define o algoritmo de criptografia

            var chaveSimetrica = new SymmetricSecurityKey(segredo);// chave compartilhada entre o emissor (quem assina) e o receptor (quem verifica a assinatura), com o segredo

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "eAgendaMedica",//emissor

                Audience = "http://localhost",//quem vai estar "chamando"

                Subject = ObterIdentityClaims(usuario),

                Expires = dataExpiracao,

                SigningCredentials = new SigningCredentials(chaveSimetrica, algoritmo) //algoritmo da criptografia

                //SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(segredo), SecurityAlgorithms.HmacSha256Signature)
            });

            string chaveToken = tokenHandler.WriteToken(token); // converte o token em uma string jwt

            return chaveToken;
        }

        private static ClaimsIdentity ObterIdentityClaims(Usuario usuario)//Informaçõe do usuario que estarão dentro da chave
        {
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()));
            claims.AddClaim(new Claim(JwtRegisteredClaimNames.Email, usuario.Email));
            claims.AddClaim(new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserName));
            claims.AddClaim(new Claim(JwtRegisteredClaimNames.GivenName, usuario.Nome));

            return claims;
        }
    }
}
