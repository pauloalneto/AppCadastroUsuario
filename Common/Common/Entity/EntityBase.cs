using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entity
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
