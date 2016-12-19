using OpendeurdagApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpendeurdagApp.ViewModels
{
    public class CampusTourViewModel: ViewModelBase
    {

        public ObservableCollection<FlipViewItem> FlipViewItems { get; set; }

        public CampusTourViewModel()
        {
            FlipViewItems = new ObservableCollection<FlipViewItem>();

            populateCollection();
        }

        private /*async*/ void populateCollection()
        {
            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_01.jpg",
                Title = "Welkom op Campus Schoonmeersen!",
                Description = "Dit is het eerst zicht dat we krijgen wanneer we de campus Schoonmeersen binnenstappen."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_02.jpg",
                Title = "Fietsenstalling",
                Description = "Aan de ingang, aan de rechterkant, vinden we meteen een ruime fietsenstalling. Honderden studenten kunnen hier dagelijks hun fiets kwijt! Achterin " 
                    + "is er ook plaats voorzien voor gemotoriseerde tweewielers."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_03.jpg",
                Title = "Een overzicht",
                Description = "Dit is een plan van de Campus Schoonmeersen. We zijn via de Voskenslaan de campus binnengelopen, passeerden de fietsenstalling, en bevinden ons nu aan gebouw C."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_04.jpg",
                Title = "Gebouw C",
                Description = "We zien gebouw C. Dit is een ouder gebouw, waar onder andere de wetenschappelijke richtingen vaak les hebben. Naast enkele grote auditoria, "
                    + "huist gebouw C ook practicalokalen en kleinere klaslokalen."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_05.jpg",
                Title = "Ingang gebouw C",
                Description = "Gebouw C is toegankelijk via een iconische draaideur. Je bent geen student op de Campus Schoonmeersen als je niet al eens vast " 
                    + "hebt gezeten in de draaideur omdat iemand hem per ongeluk tegenhield."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_06-1.jpg",
                Title = "Gebouw C",
                Description = "We passeren gebouw C en zien in de verte gebouw D reeds opdoemen."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_06-2.jpg",
                Title = "Groen op HoGent",
                Description = "Uw verslaggevers van dienst! Zoals je ziet is er ook veel groen aanwezig op de campus. De foto is op een koude herfstdag genomen, maar in de zomer " 
                    +  "zijn deze kleine parkjes de favoriete plaatsen van de studenten om hun lunch te komen opeten."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_07.jpg",
                Title = "Gebouw D",
                Description = "We naderen gebouw D. Een zeer opvallend gebouw, met rechts het glaswerk van de bibliotheek. Eronder bevindt zich de selfservice van Resto D. " 
                    + "Ernaast, in de verte, zien we ook het voetbalplein. Tijdens de zomerblok kunnen studenten zich hier elke namiddag een uurtje ontspannen door aan sport te doen."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_08.jpg",
                Title = "Gebouw D",
                Description = "We stappen binnen in gebouw D. Gebouw D heeft een grote open hal waar we nu door zullen lopen, heel indrukwekkend!"
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_09.jpg",
                Title = "ING Geldautomaat",
                Description = "Campus Schoonmeersen heeft ook haar eigen geldautomaat! Geen excuus om elke middag bij je medestudenten geld te lenen om een maaltijd te " 
                    + "kunnen nuttigen, want het automaat staat in het midden van de campus. Handig!"
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_10.jpg",
                Title = "Gebouw D",
                Description = "We lopen door de hal van gebouw D. Links bevinden zich de bureaus van het administratief personeel van HoGent, rechts resto D en de bib."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_11.jpg",
                Title = "Campusshop Standaard Boekhandel",
                Description = "Naast een geldautomaat, beschikt Campus Schoonmeersen ook over haar eigen Standaard Boekhandel Studentenshop. Hier kunnen studenten hun " 
                    + "cursussen kopen, bestellen en ophalen."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_12.jpg",
                Title = "Resto en BYB",
                Description = "Aan de andere kant van de hal zien we de resto en de bibliotheek."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_13.jpg",
                Title = "BYB - Bytes & Books",
                Description = "BYB is de bib van de campus Schoonmeersen. Naast leerrijke naslagwerken, bevinden zich in deze bib vooral veel studerende studenten. " 
                    + "In de blok is dit de favoriete plaats van menig student om die cursussen in zijn hoofd te stampen."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_14.jpg",
                Title = "BYB - Bytes & Books",
                Description = "Wanneer we binnenstappen, zijn er inderdaad blokkende studenten te zien. En een serial killer?"
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_15.jpg",
                Title = "Resto D",
                Description = "Onder de BYB vinden we Resto D. Hier lunchen de studenten over de middag. Resto D beschikt ook over een selfservice restaurant, " 
                    + "waar er belegde broodjes, verschillende maaltijden (met elke dag variatie), soep en desserts worden geserveerd."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_16.jpg",
                Title = "Java Coffee House",
                Description = "Hmmmm, Java Coffee! Alsof studenten op de Campus Schoonmeersen nog niet genoeg verwend worden, hebben ze ook nog heerlijke Java " 
                    + "koffie ter hun beschikking! Wie graag wat meer wilt dan de koffie uit het automaat en daar graag een centje meer voor betaalt, kan hier " 
                    + "terecht voor een heerlijke beker premium Java koffie. De populairdere tijdschriften en handelsbladen zijn hier ook te verkrijgen."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_17.jpg",
                Title = "Resto B",
                Description = "We bereiken de ingang van campus B. Hier zijn de studenten van Faculteit Bedrijf & Organisatie het vaakst terug te vinden."
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "/Assets/Tour/IMG_18.jpg",
                Title = "Parking",
                Description = "Hoewel HoGent haar studenten aanspoort om met het openbaar vervoer of met de fiets naar de les te komen, beseffen we dat dit niet voor " 
                    + "iedereen mogelijk is. Hier zien we de zeer uitgebreide parking. Kom wel op tijd met de auto, want reeds vanaf 8u00 zijn alle plaatsjes volzet!"
            });

            FlipViewItems.Add(new FlipViewItem()
            {
                ImageSource = "http://www.rubenvermeulen.be/files/hogent/hogent-schoonmeersen.jpg",
                Title = "Campus Schoonmeersen - studeren met plezier!",
                Description = "Dit was een kleine rondleiding doorheen campus Schoonmeersen. De campus staat elke weekdag voor je open, dus aarzel zeker niet om eens " 
                    + "langs te komen als met je eigen ogen eens te komen bekijken."
            });

        }
    }
}
