using System.ComponentModel.DataAnnotations.Schema;

namespace SAB.Framework.DbRepository.Infra
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}