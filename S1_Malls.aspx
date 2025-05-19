<%@ Page Title="" Language="C#" MasterPageFile="~/Site1_Customer.Master" AutoEventWireup="true" CodeBehind="S1_Malls.aspx.cs" Inherits="badpj_integration_trial4.S1_Malls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
    <link href="/Css/S1_HomeCard.css" rel="stylesheet" />

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/3.5.1/gsap.min.js"></script>
    <h2 style="margin-left:2%;">Our Partners</h2>
    <div class="card-container" style="height: 520px;">
        <contenttemplate>
            <div class="display">
                <div class="row">
                    <asp:Repeater ID="MallInfoRepeater" runat="server">
                        <ItemTemplate>
                            <div class="col-sm-3" style="margin-bottom: 27px;">
                                <div class="card">
                                    <img class="card-img-top" src='<%# "/Imgs/" + Eval("Mall_Image") %>' alt="Card image cap">
                                    <div class="card-body" style="display: grid; grid-template-columns: auto auto;">
                                        <div class="card-body-split">
                                            <h5 class="card-text" style="font-weight: bold;"><%# Eval("Mall_Name") %></h5>
                                            <p class="card-text"><%# Eval("Mall_Location") %></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </contenttemplate>
    </div>
 

    <!-- SCRIPTS -->
    <script>
        function searchOutlet() {
            // Get the input field value
            let input = document.getElementById("search-input").value;
            // Get the Repeater elements
            let mallInfoElements = document.getElementsByClassName("col-sm-3");
            // Get the no results message element
            let noResultsMessage = document.getElementById("no-results-message");
            let hasResults = false;
            // Loop through the Repeater elements
            for (let i = 0; i < mallInfoElements.length; i++) {
                // Get the outlet name element
                let outletName = mallInfoElements[i].getElementsByTagName("h5")[0];
                // Get the mall name element
                let mallName = mallInfoElements[i].getElementsByTagName("p")[0];
                // If the outlet name or mall name does match the search input, show the element
                if (outletName.innerHTML.toUpperCase().indexOf(input.toUpperCase()) > -1 || mallName.innerHTML.toUpperCase().indexOf(input.toUpperCase()) > -1) {
                    mallInfoElements[i].style.display = "";
                    hasResults = true;
                } else {
                    mallInfoElements[i].style.display = "none";
                }
            }
            // If there are no matches, show the no results message
            if (!hasResults) {
                noResultsMessage.style.display = "";
            } else {
                noResultsMessage.style.display = "none";
            }
        }
        // Add event listener to the search input field to trigger the search function
        document.getElementById("search-input").addEventListener("keyup", searchOutlet);
    </script>

    <script>
        function generateRandomNumber() {
            var elements = document.getElementsByClassName("random-number");
            for (var i = 0; i < elements.length; i++) {
                var max = parseInt(elements[i].getAttribute('data-outlet-seatno'));
                var min = 1;
                var randomNumber = Math.floor(Math.random() * (max - min + 1)) + min;
                var percent = (randomNumber / max) * 100;
                elements[i].innerHTML = randomNumber;

                if (percent < 30) {
                    elements[i].style.color = "red";
                } else if (percent >= 31 && percent <= 50) {
                    elements[i].style.color = "orange";
                } else {
                    elements[i].style.color = "green";
                }
            }
        }

        window.onload = function () {
            generateRandomNumber();
            setInterval(generateRandomNumber, 10000);
        }
    </script>

    <script>
        document.body.addEventListener("mousemove", evt => {
            const mouseX = evt.clientX;
            const mouseY = evt.clientY;
            gsap.set(".cursor", {
                x: mouseX,
                y: mouseY
            });
            gsap.to(".shape", {
                x: mouseX,
                y: mouseY,
                stagger: -0.1
            });
        });
    </script>

</asp:Content>
