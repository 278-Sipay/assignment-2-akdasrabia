namespace SipayApi.Schema;

public class AccountRequest
{
    public int AccountNumber { get; set; }
    public int CustomerNumber { get; set; }
    public string Name { get; set; }
    public string CurrencyCode { get; set; }
}
