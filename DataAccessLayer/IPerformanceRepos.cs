using Performances.Models;

namespace Performances.DataAccessLayer
{
    public interface IPerformanceRepos
    {
        public Performance GetPerformanceById(int id);
        public IEnumerable<Performance> GetPerformances();

        // 4 Add new performance
        public Performance AddPerformance(Performance performance);

        // 5 Delete performance
        public void DeletePerformance(Performance performance);
    }
}
