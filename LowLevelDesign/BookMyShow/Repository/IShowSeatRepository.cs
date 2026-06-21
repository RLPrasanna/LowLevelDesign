using BookMyShow.Model.Enums;

namespace BookMyShow.Repository
{
    public interface IShowSeatRepository : IRepository<Model.ShowSeat>
    {
        List<Model.ShowSeat> GetByShowId(long showId);
        Dictionary<SeatType, double> GetSeatTypePrices(List<SeatType> seatTypes);
    }
}
