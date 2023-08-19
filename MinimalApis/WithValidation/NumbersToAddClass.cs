namespace MinimalApis.WithValidation;

public class NumbersToAddClass
{
    public int Number1 { get; set; }
    //set to nullable so that it doesn't infer to zero
    //when submitting a post message with the number
    public int? Number2 { get; set; }
}