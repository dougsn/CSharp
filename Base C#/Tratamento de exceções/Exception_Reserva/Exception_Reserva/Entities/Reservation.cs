using Exception_Reserva.Entities.Exceptions;

namespace Exception_Reserva.Entities {
    internal class Reservation {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation() {
        }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut) {

            if (checkOut <= checkIn) { // Validando se a data de entrada não é mais ou igual a data de saída
                throw new DomainException("Check-out date must be after check-in date");
            }

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public double Duration() { // Calculando os dias da reserva.
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut) {

            DateTime now = DateTime.Now;
            if (checkIn < now || checkOut < now) { // Validando se a data de entrada ou de saida não são menores que a data atual
                throw new DomainException("Reservation dates for update must be future dates");
            } else if (checkOut <= checkIn) { // Validando se a data de saída não é menor que a data de entrara.
                throw new DomainException("Check-out date must be after check-in date");
            }

            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public override string ToString() {
            return "Room "
                + RoomNumber
                + ", check-in: "
                + CheckIn.ToString("dd/MM/yyyy")
                + ", check-out: "
                + CheckOut.ToString("dd/MM/yyyy")
                + ", "
                + Duration()
                + " nights";
        }
    }
}
