using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.RegionsDto;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.RegionLogic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.RegionLogic
{
    public class GetRegions : Logic<GetRegionsInput, GetRegionsOutput>
    {
        public GetRegions(IUnitofWork uow,
                string firstExecutedLogicName,
                bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

        public override void DoExecute()
        {
            Result.Output.Regions = _uow.GetRepository<Region>().GetAll().Select(x => new RegionDto
            {
                Id = x.Id,
                Name = x.Name,
                AddedDate = x.AddedDate,
                ParentId = x.ParentId
            }).ToList();
            return;
        }
    }
}
