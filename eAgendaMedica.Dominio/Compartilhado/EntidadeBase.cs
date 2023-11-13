﻿using Taikandi;

namespace eAgendaMedica.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            this.Id = SequentialGuid.NewGuid();
        }
    }
}
