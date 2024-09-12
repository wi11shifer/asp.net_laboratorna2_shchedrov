using System.Collections.Generic;
using System.Linq;
using System.Xml;
using IniParser;
using Microsoft.Extensions.Configuration;
using Shschedrov_Bohdan_Laboratorna_2.Models;
using System.Text.Json;

namespace Shschedrov_Bohdan_Laboratorna_2.Services
{
    public class CompanyService
    {
        private readonly IConfiguration _configuration;

        public Company GetLargestCompany()
        {
            var companies = new List<Company>();

            // JSON
            try
            {
                var json = File.ReadAllText("Config/companies.json");
                var jsonCompanies = JsonSerializer.Deserialize<List<Company>>(json);
                companies.AddRange(jsonCompanies);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error reading JSON: {ex.Message}");
            }

            // XML
            var xmlCompanies = new List<Company>();
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("Config/companies.xml");
            foreach (XmlNode node in xmlDoc.SelectNodes("//Company"))
            {
                var company = new Company
                {
                    Name = node["Name"].InnerText,
                    Employees = int.Parse(node["Employees"].InnerText)
                };
                xmlCompanies.Add(company);
            }
            companies.AddRange(xmlCompanies);

            // INI
            var parser = new FileIniDataParser();
            var data = parser.ReadFile("Config/companies.ini");
            foreach (var section in data.Sections)
            {
                var company = new Company
                {
                    Name = section.SectionName,
                    Employees = int.Parse(data[section.SectionName]["Employees"])
                };
                companies.Add(company);
            }

            return companies.OrderByDescending(c => c.Employees).FirstOrDefault();
        }
    }

}
