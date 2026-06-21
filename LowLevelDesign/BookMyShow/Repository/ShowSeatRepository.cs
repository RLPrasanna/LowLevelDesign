using BookMyShow.Data;
using BookMyShow.Model.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookMyShow.Repository
{
    public class ShowSeatRepository : Repository<Model.ShowSeat>, IShowSeatRepository
    {
        private readonly AppDBContext _dbContext;

        public ShowSeatRepository(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Model.ShowSeat> GetByShowId(long showId)
        {
            return _dbContext.Set<Model.ShowSeat>()
                .Include(x => x.Show)
                .Include(x => x.Seat)
                .Where(x => EF.Property<long>(x, "ShowId") == showId)
                .ToList();
        }

        public Dictionary<SeatType, double> GetSeatTypePrices(List<SeatType> seatTypes)
        {
            return seatTypes.Distinct().ToDictionary(seatType => seatType, seatType => seatType switch
            {
                SeatType.Recliner => 500.0,
                SeatType.Gold => 300.0,
                SeatType.Silver => 150.0,
                _ => throw new ArgumentOutOfRangeException(nameof(seatType), $"Not expected seat type value: {seatType}")
            });
        }
    }
}
