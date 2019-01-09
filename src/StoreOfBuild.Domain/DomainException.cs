namespace StoreOfBuild.Domain
{
    public class DomainException
    {
        public static void When(bool hasError, string error){
            if(!hasError)
                throw new DomainException(error);
            
        }
    }
}