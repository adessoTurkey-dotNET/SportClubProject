namespace VolleyballClub.Application.Exceptions
{
    public class MyExceptions : Exception
    {
        public MyExceptions(string str, Exception exception) : base(str, exception)
        {

        }

    }
}
