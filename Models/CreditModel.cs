﻿using System.ComponentModel.DataAnnotations;

namespace LaLlamaDelBosque.Models
{
    public class CreditModel
    {
        public IList<Credit> Credits { get; set; } = new List<Credit>();

    }
    public class Client 
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        [RegularExpression(@"506[0-9]{8}", ErrorMessage = "Este número no es válido.")]
        public string Phone { get; set; } = "";
        public double? Limit { get; set; }

    }
    public class CreditLine
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Description { get; set; } = "";
        public double Amount { get; set; }

    }
    public class CreditSummary
    {
        public double Total { get; set; }
		public int Status { get; set; }
		public void CalculateStatus(double? limit)
		{

			if(Total > limit)
			{
				Status = 4;
			}
			else if(Total == limit)
			{
				Status = 3;
			}
			else if(Total < limit)
			{
				Status = 2;
			}
			else
			{
				Status = 1;
			}
		}
	}
    public class Credit
    {
        public Client Client { get; set; } = new Client();
        public IList<CreditLine> CreditLines { get; set; } = new List<CreditLine>();
        public CreditSummary CreditSummary { get; set; } = new CreditSummary();

    }

}
