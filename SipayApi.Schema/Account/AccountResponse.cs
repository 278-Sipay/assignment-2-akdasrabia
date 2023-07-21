namespace SipayApi.Schema;

public class AccountResponse
{
    public int AccountNumber { get; set; }
    public int CustomerNumber { get; set; }
    public decimal Balance { get; set; }
    public string Name { get; set; }
    public string CurrencyCode { get; set; }
    public bool IsActive { get; set; }

    public virtual List<TransactionResponse> Transactions { get; set; }
}
