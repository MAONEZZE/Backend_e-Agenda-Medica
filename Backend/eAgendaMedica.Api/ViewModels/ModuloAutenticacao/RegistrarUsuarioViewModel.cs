﻿namespace eAgendaMedica.Api.ViewModels.ModuloAutenticacao
{
    public class RegistrarUsuarioViewModel : AutenticadorBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
