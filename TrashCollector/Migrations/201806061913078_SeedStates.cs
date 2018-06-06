namespace TrashCollector.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    
    public partial class SeedStates : DbMigration
    {
        public override void Up()
        {
            var states = new Dictionary<string, string>();
            states.Add("AL", "ALABAMA");
            states.Add("AK", "ALASKA");
            states.Add("AZ", "ARIZONA");
            states.Add("AR", "ARKANSAS");
            states.Add("CA", "CALIFORNIA");
            states.Add("CO", "COLORADO");
            states.Add("CT", "CONNECTICUT");
            states.Add("DE", "DELAWARE");
            states.Add("FL", "FLORIDA");
            states.Add("GA", "GEORGIA");
            states.Add("HI", "HAWAII");
            states.Add("ID", "IDAHO");
            states.Add("IL", "ILLINOIS");
            states.Add("IN", "INDIANA");
            states.Add("IA", "IOWA");
            states.Add("KS", "KANSAS");
            states.Add("KY", "KENTUCKY");
            states.Add("LA", "LOUISIANA");
            states.Add("ME", "MAINE");
            states.Add("MD", "MARYLAND");
            states.Add("MA", "MASSACHUSETTS");
            states.Add("MI", "MICHIGAN");
            states.Add("MN", "MINNESOTA");
            states.Add("MS", "MISSISSIPPI");
            states.Add("MO", "MISSOURI");
            states.Add("MT", "MONTANA");
            states.Add("NE", "NEBRASKA");
            states.Add("NV", "NEVADA");
            states.Add("NH", "NEW HAMPSHIRE");
            states.Add("NJ", "NEW JERSEY");
            states.Add("NM", "NEW MEXICO");
            states.Add("NY", "NEW YORK");
            states.Add("NC", "NORTH CAROLINA");
            states.Add("ND", "NORTH DAKOTA");
            states.Add("OH", "OHIO");
            states.Add("OK", "OKLAHOMA");
            states.Add("OR", "OREGON");
            states.Add("PA", "PENNSYLVANIA");
            states.Add("RI", "RHODE ISLAND");
            states.Add("SC", "SOUTH CAROLINA");
            states.Add("SD", "SOUTH DAKOTA");
            states.Add("TN", "TENNESSEE");
            states.Add("TX", "TEXAS");
            states.Add("UT", "UTAH");
            states.Add("VT", "VERMONT");
            states.Add("VA", "VIRGINIA");
            states.Add("WA", "WASHINGTON");
            states.Add("WV", "WEST VIRGINIA");
            states.Add("WI", "WISCONSIN");
            states.Add("WY", "WYOMING");

            foreach (var state in states)
            {
                Sql($"INSERT INTO States (AbbreviationShort, Name) VALUES ('{state.Key}', '{state.Value}')");
            }

        }

        public override void Down()
        {
        }
    }
}
