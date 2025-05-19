<%@ Page Title="" Language="C#" MasterPageFile="~/Site2_Partner.Master" AutoEventWireup="true" CodeBehind="S1_FAQ.aspx.cs" Inherits="badpj_integration_trial4.S1_FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <meta charset="utf-8" />
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous">s</script>
        <h1>Frequently Asked Questions (FAQs)</h1>
        <div class="accordion accordion-flush"
            id="accordionExample">
            <div class="accordion-item">
                <h2 class="accordion-header"
                    id="headingOne">
                    <button class="accordion-button"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#collapseOne"
                        aria-expanded="true"
                        aria-controls="collapseOne">
                        What is CrowdFeed?
                    </button>
                </h2>
                <div id="collapseOne"
                    class="accordion-collapse collapse show"
                    aria-labelledby="headingOne"
                    data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        CrowdFeed is an application to help customers to dine quickly and easily at their nearest F&B outlets. Essentially, bringing crowds for restaurants to feed.
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header"
                    id="headingTwo">
                    <button class="accordion-button collapsed"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#collapseTwo"
                        aria-expanded="false"
                        aria-controls="collapseTwo">
                        How do I use CrowdFeed?
                    </button>
                </h2>
                <div id="collapseTwo"
                    class="accordion-collapse collapse"
                    aria-labelledby="headingTwo"
                    data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        Download the app and get started on your journey.
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header"
                    id="headingThree">
                    <button class="accordion-button collapsed"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#collapseThree"
                        aria-expanded="false"
                        aria-controls="collapseThree">
                        How do i get in business with CrowdFeed?
                    </button>
                </h2>
                <div id="collapseThree"
                    class="accordion-collapse collapse"
                    aria-labelledby="headingThree"
                    data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        Contact us via any of our communication channels and we'll get in touch with you soon!
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header"
                    id="headingFour">
                    <button class="accordion-button collapsed"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#collapseFour"
                        aria-expanded="false"
                        aria-controls="collapseFour">
                        What is ProSensors?                    
                    </button>
                </h2>
                <div id="collapseFour"
                    class="accordion-collapse collapse"
                    aria-labelledby="headingFour"
                    data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        ProSensors is a company that has developed proximity capacitive sensors for detecting people and object occupancy in real-time.                   
                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header"
                    id="headingFive">
                    <button class="accordion-button collapsed"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#collapseFive"
                        aria-expanded="false"
                        aria-controls="collapseFive">
                        How does the ProSensors sensor work?                     
                    </button>
                </h2>
                <div id="collapseFive"
                    class="accordion-collapse collapse"
                    aria-labelledby="headingFive"
                    data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        The sensor is made of copper foils and a Raspberry Pi with a controller chip MPR121, and it comes in a small and thin circular shape with rounded edges. It can be easily deployed under tables using the adhesive side, and it transmits data to the CrowdFeed application through a wifi transmitter.               
                    </div>
                </div>

            </div>
            <div class="accordion-item">
                <h2 class="accordion-header"
                    id="headingSix">
                    <button class="accordion-button collapsed"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#collapseSix"
                        aria-expanded="false"
                        aria-controls="collapseSix">
                        What upkeep or installation is needed for the sensors?                    
                    </button>
                </h2>
                <div id="collapseSix"
                    class="accordion-collapse collapse"
                    aria-labelledby="headingSix"
                    data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        The sensors are powered by long-lasting lithium batteries that will be changed every 6 months or when the mall schedules maintenance service. There will be an initial installation fee of 10% and a 5% maintenance fee on top of the final fee and $300 for consecutive maintenance.                   
                    </div>
                </div>

            </div>
            <div class="accordion-item">
                <h2 class="accordion-header"
                    id="headingSeven">
                    <button class="accordion-button collapsed"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#collapseSeven"
                        aria-expanded="false"
                        aria-controls="collapseSeven">
                        What are the main values of CrowdFeed?                    
                    </button>
                </h2>
                <div id="collapseSeven"
                    class="accordion-collapse collapse"
                    aria-labelledby="headingSeven"
                    data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        The main values of CrowdFeed are providing accurate occupancy rates, acting as a directory for a mall's food scene, being interactive and user-friendly, creating a new market, and providing opportunities for growth potential and competitive advantage.                   
                    </div>
                </div>

            </div>
            <div class="accordion-item">
                <h2 class="accordion-header"
                    id="headingEight">
                    <button class="accordion-button collapsed"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#collapseEight"
                        aria-expanded="false"
                        aria-controls="collapseEight">
                        How will CrowdFeed benefit users?                    
                    </button>
                </h2>
                <div id="collapseEight"
                    class="accordion-collapse collapse"
                    aria-labelledby="headingEight"
                    data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        CrowdFeed will benefit users by relieving the stress of finding available seats, serving as an overview of F&B outlets in a mall, allowing users to filter through outlets based on their needs and wants, and making decisions easier and faster.                   
                    </div>
                </div>

            </div>
            <div class="accordion-item">
                <h2 class="accordion-header"
                    id="headingNine">
                    <button class="accordion-button collapsed"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#collapseNine"
                        aria-expanded="false"
                        aria-controls="collapseNine">
                        What is the lifespan of CrowdFeed's product?                    
                    </button>
                </h2>
                <div id="collapseNine"
                    class="accordion-collapse collapse"
                    aria-labelledby="headingNine"
                    data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        CrowdFeed's sensors have been designed to last for up to 5 years, during which time the company will strive to research and improve the quality of its product.                   
                    </div>
                </div>

            </div>
        </div>
</asp:Content>

