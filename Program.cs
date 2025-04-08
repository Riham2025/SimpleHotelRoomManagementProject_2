using System.Net.NetworkInformation;

namespace SimpleHotelRoomManagementProject_2
{
    internal class Program
    {
        static int[] RoomNumber = new int[100];
        static double[] roomRates = new double[100];
        static bool[] isReserved = new bool[100];
        static string[] guestNames = new string[100];
        static int[] nights = new int[100];
        static DateTime[] bookingDates = new DateTime[100];
        static int roomCount = 0;


        static void Main(string[] args)
        {


            Console.WriteLine("Hello, World!");
            int choiceNum;

            while (true)
            {

                try
                {

                    Console.Clear();

                    Console.WriteLine("Simple Hotel Room Management Project..");
                    Console.WriteLine("1. Add a new room..");
                    Console.WriteLine("2. View all rooms..");
                    Console.WriteLine("3. Reserve a room for a guest..");
                    Console.WriteLine("4. View all reservations with total cost..");
                    Console.WriteLine("5. Search reservation by guest name..");
                    Console.WriteLine("6. Find the highest-paying guest..");
                    Console.WriteLine("7. Cancel a reservation by room number.. ");
                    Console.WriteLine("0. Exit.. ");
                    Console.Write("Enter The Number Of Feature: ");

                    choiceNum = int.Parse(Console.ReadLine());


                    switch (choiceNum)
                    {
                        case 1: AddNewRoom(); break;
                        case 2: ViewAllRooms(); break;
                        case 3: ReserveRoom(); break;
                        case 4: ViewAllReservations(); break;
                        case 5: SearchReservationByGuestName(); break;
                        case 6: FindTheHighestPayingGuest(); break;
                        case 7: AddNewRoom(); break;
                        case 0: return;
                        default: Console.WriteLine("Invalid choice! Try again."); break;
                    }
                    Console.ReadLine();
                }
                catch (Exception e)
                {

                    Console.WriteLine($"Error: {e.Message}");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadKey();

                }
            }

            //1. Add a new room (Room Number, Daily Rate)
            static void AddNewRoom()
            {
                Console.WriteLine("Enter Room Number: ");
                RoomNumber[roomCount] = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Daily Rate: ");
                roomRates[roomCount] = double.Parse(Console.ReadLine());
                isReserved[roomCount] = false;
                guestNames[roomCount] = "";
                nights[roomCount] = 0;
                bookingDates[roomCount] = DateTime.MinValue;
                roomCount++;
                Console.WriteLine("Room added successfully!");

            }


            //2. View All Rooms (Available + Reserved)
            static void ViewAllRooms()
            {

                Console.WriteLine("Room Number\tDaily Rate\tReserved\tGuest Name\tNights\tBooking Date");
                for (int i = 0; i < roomCount; i++)
                {
                    Console.WriteLine($"{RoomNumber[i]}\t\t{roomRates[i]}\t\t{(isReserved[i] ? "Yes" : "No")}\t\t{guestNames[i]}\t\t{nights[i]}\t{bookingDates[i]}");
                }
            }

            //3. Reserve a Room 
            static void ReserveRoom()
            {
                Console.WriteLine("Enter Room Number to reserve: ");
                int roomNumber = int.Parse(Console.ReadLine());
                int index = Array.IndexOf(RoomNumber, roomNumber);
                if (index == -1)
                {
                    Console.WriteLine("Room not found!");
                    return;
                }
                if (isReserved[index])
                {
                    Console.WriteLine("Room is already reserved!");
                    return;
                }
                Console.WriteLine("Enter Guest Name: ");
                guestNames[index] = Console.ReadLine();
                Console.WriteLine("Enter Number of Nights: ");
                nights[index] = int.Parse(Console.ReadLine());
                bookingDates[index] = DateTime.Now;
                isReserved[index] = true;
                Console.WriteLine("Room reserved successfully!");
            }

            //4. View All Reservations

            static void ViewAllReservations()
            {
                Console.WriteLine("Room Number\tGuest Name\tNights\tBooking Date\tTotal Cost");
                for (int i = 0; i < roomCount; i++)
                {
                    if (isReserved[i])
                    {
                        double totalCost = roomRates[i] * nights[i];
                        Console.WriteLine($"{RoomNumber[i]}\t\t{guestNames[i]}\t\t{nights[i]}\t{bookingDates[i]}\t{totalCost}");
                    }
                }
            }

            //5. Search Reservation by Guest Name
            static void SearchReservationByGuestName()
            {
                Console.WriteLine("Enter Guest Name to search: ");
                string guestName = Console.ReadLine();
                bool found = false;
                for (int i = 0; i < roomCount; i++)
                {
                    if (guestNames[i].Equals(guestName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Room Number: {RoomNumber[i]}, Nights: {nights[i]}, Booking Date: {bookingDates[i]}");
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("No reservation found for this guest.");
                }
            }

            //6. Find the highest-paying guest
            static void FindTheHighestPayingGuest()
            {
                Console.WriteLine(
                    "Room Number\tGuest Name\tNights\tBooking Date\tTotal Cost");
                double maxCost = 0;
                string highestPayingGuest = "";

                for (int i = 0; i < roomCount; i++)
                {
                    if (isReserved[i])
                    {
                        double totalCost = roomRates[i] * nights[i];
                        if (totalCost > maxCost)
                        {
                            maxCost = totalCost;
                            highestPayingGuest = guestNames[i];
                        }
                    }
                }
                if (highestPayingGuest != "")
                {
                    Console.WriteLine($"Highest Paying Guest: {highestPayingGuest}, Total Cost: {maxCost}");
                }
                else
                {
                    Console.WriteLine("No reservations found.");
                }





            }

            //7. Cancel a reservation by room number
            static void CancelReservation()
            {
                Console.WriteLine("Enter Room Number to cancel reservation: ");
                int roomNumber = int.Parse(Console.ReadLine());
                int index = Array.IndexOf(RoomNumber, roomNumber);
                if (index == -1)
                {
                    Console.WriteLine("Room not found!");
                    return;
                }
                if (!isReserved[index])
                {
                    Console.WriteLine("Room is not reserved!");
                    return;
                }
                isReserved[index] = false;
                guestNames[index] = "";
                nights[index] = 0;
                bookingDates[index] = DateTime.MinValue;
                Console.WriteLine("Reservation cancelled successfully!");
            }



        }
    }
}