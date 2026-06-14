using ParkingLotManagement.DTO;
using ParkingLotManagement.Model;
using ParkingLotManagement.Service;
using System;

namespace ParkingLotManagement.Controller
{
    internal class BillController
    {
        private IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        public BillResponseDTO GenerateBill(BillRequestDTO request)
        {
            try
            {
                Bill bill = _billService.GenerateBill(request.TicketNumber, request.GateId);

                return new BillResponseDTO
                {
                    ResponseStatus = Model.Enums.ResponseStatus.SUCCESS,
                    Bill = bill
                };
            }
            catch (Exception ex)
            {
                return new BillResponseDTO
                {
                    ResponseStatus = Model.Enums.ResponseStatus.FAILURE,
                    FailureMessage = ex.Message
                };
            }
        }
    }
}
