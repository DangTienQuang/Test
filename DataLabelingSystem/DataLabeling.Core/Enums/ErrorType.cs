namespace DataLabeling.Core.Enums
{
    public enum ErrorType
    {
        None = 0,          
        WrongLabel = 1,         
        InaccurateBox = 2,     
        MissingObject = 3,      
        InstructionViolation = 4, 
        Other = 99              
    }
}