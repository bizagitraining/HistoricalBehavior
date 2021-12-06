using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for ClientBehavior
/// </summary>
[Serializable]
public class ClientBehavior
{
    private string clientID;
    private List<Historical> historical;
    private Message message;


    public ClientBehavior()
    {
        this.Message = new Message();
        this.Historical = new List<Historical>();
    }

    public string ClientID
    {
        get { return clientID; }
        set { clientID = value; }
    }

    public List<Historical> Historical
    {
        get { return historical; }
        set { historical = value; }
    }

    public Message Message
    {
        get { return message; }
        set { message = value; }
    }

}

public class Historical
{
    private string corporation;
    private string product;
    private string productCode;
    private double score;
    private string status;
    private DateTime queryDate;

    public string Corporation
    {
        get { return corporation; }
        set { corporation = value; }
    }

    public string Product
    {
        get { return product; }
        set { product = value; }
    }

    public string ProductCode
    {
        get { return productCode; }
        set { productCode = value; }
    }

    public double Score
    {
        get { return score; }
        set { score = value; }
    }

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

    public DateTime QueryDate
    {
        get { return queryDate; }
        set { queryDate = value; }
    }


}

public class Message
{
    private int errorCode;
    private string errorMessage;



    public Message()
    {
        this.ErrorCode = 0;
    }

    public int ErrorCode
    {
        get { return errorCode; }
        set { errorCode = value; }
    }

    public string ErrorMessage
    {
        get { return errorMessage; }
        set { errorMessage = value; }
    }

}