using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{

    private string[] sArLoans = { "Credit Card", "Car Loan", "Study Loan", "Personal Loan", "Home Loan", "Debt Consolidation Loan", "Home Improvement Loan", "Secured Loan" };
    private string[] sArCorporations = { "BBVA", "Santander", "CitiBank" };
    private string[] sArMonths = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DEC" };
    private string[] sArBehav = { "Excellent behavior.", "Good behavior with some late payments.", "Bad behavior", "Bad behavior with arrears", };





    #region Object Services


    public ClientBehavior historicalBehavior(string idUser)
    {

        ClientBehavior clientResponse = new ClientBehavior();
        clientResponse.ClientID = idUser;

        clientResponse = getHistoricalBehavior(clientResponse);


        return clientResponse;

    }


    private ClientBehavior getHistoricalBehavior(ClientBehavior client)
    {
        GenerateUniqueRandomNumber RandomResponse = new GenerateUniqueRandomNumber(0, 100);
        GenerateUniqueRandomNumber RandomScoring = new GenerateUniqueRandomNumber(1, 10);
        GenerateUniqueRandomNumber RandomCorporation = new GenerateUniqueRandomNumber(0, 2);
        GenerateUniqueRandomNumber RandomProductcode = new GenerateUniqueRandomNumber(1, 9);
        GenerateUniqueRandomNumber RandomProduct = new GenerateUniqueRandomNumber(0, 7);

        double response = RandomResponse.NewRandomNumber();
        if (response != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Historical historical = new Historical();
                double score = RandomScoring.NewRandomNumber();
                string status = "";
                if (score <= 4)
                    status = sArBehav[3];
                if (score >= 5 && score < 7)
                    status = sArBehav[2];
                if (score >= 7 && score <= 8)
                    status = sArBehav[1];
                if (score >= 9)
                    status = sArBehav[0];


                historical.Corporation = sArCorporations[RandomCorporation.NewRandomNumber()]; ;
                historical.Product = sArLoans[RandomProduct.NewRandomNumber()]; ;
                historical.ProductCode = "AAA" + RandomProductcode.NewRandomNumber().ToString();
                historical.Score = score;
                historical.QueryDate = DateTime.Now.AddMonths(-i);
                historical.Status = status;
                client.Historical.Add(historical);

            }
        }
        else
        {
            client.Message.ErrorCode = 1;
            client.Message.ErrorMessage = "The client id does not exist";
        }


        return client;

    }

    #endregion

}
