using System.ComponentModel.DataAnnotations.Schema;

namespace SAB.Framework.DbRepository.Infra
{
    public abstract partial class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}