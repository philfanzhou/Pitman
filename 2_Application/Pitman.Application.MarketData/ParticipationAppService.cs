using Ore.Infrastructure.MarketData;
using Pitman.Domain.FileStructure;
using Pitman.Infrastructure.SqlCe.Repository;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class ParticipationAppService
    {
        public bool Exists(string stockCode, IParticipation participation)
        {
            ParticipationRepository repository = new ParticipationRepository(DataFiles.GetParticipationFile(stockCode));
            return repository.Exists(participation);

            //// 设置查询条件
            //var spec = Specification<Participation>.Eval(p => p.Time.Equals(participation.Time));

            //using (var context = GetContext(stockCode))
            //{
            //    var repository = new Repository<Participation>(context);
            //    return repository.Exists(spec);
            //}
        }

        public void Add(string stockCode, IParticipation participation)
        {
            ParticipationRepository repository = new ParticipationRepository(DataFiles.GetParticipationFile(stockCode));
            repository.AddRange(new IParticipation[] { participation });

            //using (var context = GetContext(stockCode))
            //{
            //    var repository = new Repository<Participation>(context);
            //    repository.Add(participation.ToDataObject());
            //    repository.UnitOfWork.Commit();
            //}
        }

        public void Update(string stockCode, IParticipation participation)
        {
            ParticipationRepository repository = new ParticipationRepository(DataFiles.GetParticipationFile(stockCode));
            repository.UpdateRange(new IParticipation[] { participation });

            //using (var context = GetContext(stockCode))
            //{
            //    var repository = new Repository<Participation>(context);
            //    repository.Update(participation.ToDataObject());
            //    repository.UnitOfWork.Commit();
            //}
        }

        public IEnumerable<IParticipation> Get(string stockCode)
        {
            ParticipationRepository repository = new ParticipationRepository(DataFiles.GetParticipationFile(stockCode));
            return repository.GetAll();

            //using (var context = GetContext(stockCode))
            //{
            //    var repository = new Repository<Participation>(context);
            //    return repository.GetAll();
            //}
        }
    }
}
