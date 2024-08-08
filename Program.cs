namespace LibraryManagementSystem
{
    class Book
    {
        private string title;
        private string author;
        private string isbn;
        private int publicationYear;
        private int? availableCopies;
        private  int borrowCopy = 0;
        public string Title
        {
            get { return title; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || int.TryParse(value, out int num))
                {
                    throw new ArgumentException($"Book name Cannot be Nullable or Integer!");
                }
                else
                {
                    title = value;
                }
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || int.TryParse(value, out int num))
                {
                    throw new ArgumentException($"Author name Cannot be Nullable or Integer!");
                }
                else
                {
                    author = value;
                }
            }
        }
        public string ISBN
        {
            get { return isbn; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || int.TryParse(value, out int num))
                {
                    throw new ArgumentException($"ISBN Cannot be Nullable or Integer!");
                }
                else
                {
                    isbn = value;
                }
            }
        }
        public int PublicationYear
        {
            get { return publicationYear; }
            set
            {
                if (value > DateTime.Now.Year || value < 1350)
                {
                    throw new ArgumentException("Invalid Publication Year Provided! (Year->1350-Recent)");
                }
                else
                {
                    publicationYear = value;
                }
            }
        }
        public int? AvailableCopies
        {
            get { return availableCopies; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Negative value is not allowed for available copies.");
                }
                availableCopies = value;
            }
        }
        public void BorrowBook(){
             if (AvailableCopies > 0)
            {
                Console.WriteLine($"--------------Taking Input---------");
                Console.Write($"How many books do you want to Borrow: ");

                if(int.TryParse(Console.ReadLine(), out borrowCopy)){
                    AvailableCopies -= borrowCopy;
                }else{
                    throw new ArgumentException("Invalid Book Number.");
                }
                
                Console.WriteLine($"============Borrowed Info=========");
                Console.WriteLine($"Thanks For Borrowing. ");
                Console.WriteLine($"Copies left: {AvailableCopies}");
            }else{
                Console.WriteLine($"No copies are Available Right Now.");
            }
        }
        public void ReturnBook(){
             if (borrowCopy > 0)
            {
                
                Console.WriteLine($"--------------Taking Input---------");
                Console.Write($"How many books do you want to Return: ");

                if(int.TryParse(Console.ReadLine(), out int returnCopy) && returnCopy <= borrowCopy){
                    AvailableCopies += returnCopy;
                    borrowCopy -= returnCopy;
                }
                else if(returnCopy > borrowCopy){
                    throw new ArgumentException($"Return is not possible You did not borrow {returnCopy} Books");
                }
                else{
                    throw new ArgumentException("Invalid Book Number.");
                }
                
                Console.WriteLine($"============Returned Info=========");
                Console.WriteLine($"Thanks For Returning. ");
                Console.WriteLine($"Copies left: {AvailableCopies}");
            }else{
                Console.WriteLine($"You did not Borrow any book. Return is not Possible");
            }
        }
        public string CheckAvailability()
        {
            if (AvailableCopies != null)
            {
                if (AvailableCopies == 0)
                {
                    return "Not Available!";
                }
                else
                {
                    return "Available";
                }
            }else{
                return "Invalid Copies!";
            }
        }
        //Setting Values
        public void SetBookInfo()
        {
            Console.Write($"Enter Your Book Name: ");
            Title = Console.ReadLine();
            Console.Write($"Enter the Author Name: ");
            Author = Console.ReadLine();
            Console.Write($"Enter the ISBN no: ");
            ISBN = Console.ReadLine();
            Console.Write($"Enter the Publication Year: ");
            PublicationYear = int.Parse(Console.ReadLine());
            Console.Write($"Enter the Book Copies: ");
            AvailableCopies = int.Parse(Console.ReadLine());
        }
        //Getting Values
        public void PrintBookInfo()
        {
            Console.WriteLine($"===========Book Information=============");
            Console.WriteLine($"Book Name: {Title}");
            Console.WriteLine($"Author Name: {Author}");
            Console.WriteLine($"ISBN Number: {ISBN}");
            Console.WriteLine($"Available Copies: {AvailableCopies}");
            Console.WriteLine($"Publication Year: {PublicationYear}");
            Console.WriteLine($"Availablity: {CheckAvailability()}");
            BorrowBook();
            ReturnBook();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Book b1 = new Book();
                b1.SetBookInfo();
                b1.PrintBookInfo();

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.ParamName}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Error: Input is Too long or Too short!");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}