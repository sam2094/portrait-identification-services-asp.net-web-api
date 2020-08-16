using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.ContractDtos;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
    public class GetTarifs : Logic<GetTarifsInput, GetTarifsOutput>
    {
        public GetTarifs(IUnitofWork uow,
                string firstExecutedLogicName,
                bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

        public override void DoExecute()
        {
            Result.Output.Tarifs = _uow.GetRepository<Tarif>().GetAll().Select(x => new GetTarifsDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();
        }
    }
}
