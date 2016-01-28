using Framework.Infrastructure.Repository;
using Ore.Infrastructure.MarketData;
using Pitman.Domain.FileStructure;
using Pitman.Infrastructure.DatabaseObject;
using Pitman.Infrastructure.EF.Repository;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class ParticipationAppService
    {
        public bool Exists(string stockCode, IParticipation participation)
        {
            // 设置查询条件
            var spec = Specification<ParticipationDbo>.Eval(p => p.Time.Equals(participation.Time));

            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<ParticipationDbo>(context);
                return repository.Exists(spec);
            }
        }

        public void Add(string stockCode, IParticipation participation)
        {
            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<ParticipationDbo>(context);
                repository.Add(ConvertToDbo(participation));
                repository.UnitOfWork.Commit();
            }
        }

        public void Update(string stockCode, IParticipation participation)
        {
            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<ParticipationDbo>(context);
                repository.Update(ConvertToDbo(participation));
                repository.UnitOfWork.Commit();
            }
        }

        public IEnumerable<IParticipation> Get(string stockCode)
        {
            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<ParticipationDbo>(context);
                return repository.GetAll();
            }
        }

        private IRepositoryContext GetContext(string stockCode)
        {
            string fullPath = DataFiles.GetParticipationFile(stockCode);
            IRepositoryContext context
                = ContextFactory.Create(ContextType.Participation, fullPath);

            return context;
        }

        private static ParticipationDbo ConvertToDbo(IParticipation self)
        {
            ParticipationDbo outputData = new ParticipationDbo
            {
                CostPrice1Day = self.CostPrice1Day,
                CostPrice20Day = self.CostPrice20Day,
                MainForceInflows = self.MainForceInflows,
                SuperLargeInflows = self.SuperLargeInflows,
                Time = self.Time,
                Value = self.Value,
            };

            return outputData;
        }
    }
}
