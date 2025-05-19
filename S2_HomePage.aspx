<%@ Page Title="" Language="C#" MasterPageFile="~/Site2_Partner.Master" AutoEventWireup="true" CodeBehind="S2_HomePage.aspx.cs" Inherits="badpj_integration_trial4.S2_HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!DOCTYPE html>
    <html>
    <head>
        <meta charset="utf-8" />
        <title>Swiper demo</title>
        <meta name="viewport"
            content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1" />
        <!-- Link Swiper's CSS -->
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper/swiper-bundle.min.css" />
        <link rel="stylesheet" href="/Css/S2_HomePage.css" />
        <!-- Bootstrap icons-->
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css" rel="stylesheet" />
        <!-- Google fonts-->
        <link rel="preconnect" href="https://fonts.gstatic.com" />
        <link href="https://fonts.googleapis.com/css2?family=Newsreader:ital,wght@0,600;1,600&amp;display=swap" rel="stylesheet" />
        <link href="https://fonts.googleapis.com/css2?family=Mulish:ital,wght@0,300;0,500;0,600;0,700;1,300;1,500;1,600;1,700&amp;display=swap" rel="stylesheet" />
        <link href="https://fonts.googleapis.com/css2?family=Kanit:ital,wght@0,400;1,400&amp;display=swap" rel="stylesheet" />
    </head>

    <body>
        <!-- Swiper -->
        <div class="swiper mySwiper">
            <div class="swiper-wrapper">
                <div class="swiper-slide">
                    <div class="col-lg-5">
                        <!-- Mashead text and app badges-->
                        <div class="mb-5 mb-lg-0 text-center text-lg-start">
                            <h1 class="display-1 lh-1 mb-3">Our Unique Sensors</h1>
                            <p class="lead fw-normal text-muted mb-5">Provides accurate data and long-battery life of at least 6 months.</p>
                            <div class="d-flex flex-column flex-lg-row align-items-center">
                                <a class="btn btn-outline-dark py-3 px-4 rounded-pill" href="S2_E_TransactionForm.aspx" target="_blank">Buy Now</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5">
                        <!-- Masthead device mockup feature-->
                        <div class="img-overlay-wrap">
                            <svg class="svgcircle" style="top: -30px;" viewBox="0 0 10 10"
                                xmlns="http://www.w3.org/2000/svg"
                                xmlns:xlink="http://www.w3.org/1999/xlink">
                                <defs>
                                    <linearGradient id="myGradient" gradientTransform="rotate(45)">
                                        <stop offset="0%" stop-color="#FDA40F" />
                                        <stop offset="100%" stop-color="#17233F" />
                                    </linearGradient>
                                </defs>

                                <!-- using my linear gradient -->
                                <circle cx="5" cy="5" r="4" fill="url('#myGradient')" />
                            </svg>
                            <img src="/Imgs/Sensors/sensor_removed.png">
                        </div>
                    </div>
                </div>
                <div class="swiper-slide">
                    <div class="col-lg-5">
                        <!-- Mashead text and app badges-->
                        <div class="mb-5 mb-lg-0 text-center text-lg-start">
                            <h1 class="display-1 lh-1 mb-3">Our Wifi Transmitters</h1>
                            <p class="lead fw-normal text-muted mb-5">Fast, Reliable and Extends Coverage Area</p>
                            <div class="d-flex flex-column flex-lg-row align-items-center">
                                <a class="btn btn-outline-dark py-3 px-4 rounded-pill" href="https://startbootstrap.com/theme/new-age" target="_blank">Buy Now</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5">
                        <!-- Masthead device mockup feature-->
                        <div class="img-overlay-wrap">
                            <svg class="svgcircle" style="top: -70px;" viewBox="0 0 10 10"
                                xmlns="http://www.w3.org/2000/svg"
                                xmlns:xlink="http://www.w3.org/1999/xlink">
                                <defs>
                                    <linearGradient id="myGradient" gradientTransform="rotate(45)">
                                        <stop offset="0%" stop-color="#FDA40F" />
                                        <stop offset="100%" stop-color="#17233F" />
                                    </linearGradient>
                                </defs>

                                <!-- using my linear gradient -->
                                <circle cx="5" cy="5" r="4" fill="url('#myGradient')" />
                            </svg>
                            <img src="/Imgs/Sensors/transmitter_removed.png">
                        </div>
                    </div>
                </div>
            </div>
            <div class="swiper-button-next"></div>
            <div class="swiper-button-prev"></div>
            <div class="swiper-pagination"></div>
        </div>
        <!-- Quote/testimonial aside-->
        <aside class="text-center bg-gradient-primary-to-secondary">
            <div class="container px-5">
                <div class="row gx-5 justify-content-center">
                    <div class="col-xl-8">
                        <div class="h2 fs-1 text-white mb-4">"An intuitive solution to a common problem that we all face, wrapped up in a single app!"</div>
                        <img src="/Imgs/Nav/straitstimesicon.png" alt="..." style="height: 5rem" /><img src="/Imgs/Nav/mothershipicon.png" alt="..." style="height: 8rem" /><img src="/Imgs/Nav/independenticon.png" alt="..." style="height: 5rem" />
                    </div>
                </div>
            </div>
        </aside>
        <!-- App features section-->
        <section id="features">
            <div class="container px-5">
                <div class="row gx-5">
                    <div class="col-md-6 mb-5">
                        <!-- Feature item-->
                        <div class="text-center">
                            <i class="bi-phone icon-feature text-gradient d-block mb-3"></i>
                            <h3 class="font-alt">User-friendly</h3>
                            <p class="text-muted mb-0">Convenient for users to quickly look for seats</p>
                        </div>
                    </div>
                    <div class="col-md-6 mb-5">
                        <!-- Feature item-->
                        <div class="text-center">
                            <i class="bi-camera icon-feature text-gradient d-block mb-3"></i>
                            <h3 class="font-alt">Easy installation</h3>
                            <p class="text-muted mb-0">Just schedule with our staffs to help install all devices</p>
                        </div>
                    </div>
                </div>
                <div class="row gx-5">
                    <div class="col-md-6 mb-5 mb-md-0">
                        <!-- Feature item-->
                        <div class="text-center">
                            <i class="bi-gift icon-feature text-gradient d-block mb-3"></i>
                            <h3 class="font-alt">Continuous repair service</h3>
                            <p class="text-muted mb-0">We provide repair services if there is any issues with the devices</p>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <!-- Feature item-->
                        <div class="text-center">
                            <i class="bi-patch-check icon-feature text-gradient d-block mb-3"></i>
                            <h3 class="font-alt">Beneficial</h3>
                            <p class="text-muted mb-0">By collaborating with CrowdFeed, your mall gets more exposure and more visitors</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- Basic features section-->
        <section class="bg-light">
            <div class="container px-5">
                <div class="row gx-5 align-items-center justify-content-center justify-content-lg-between">
                    <div class="col-12 col-lg-5">
                        <h2 class="display-4 lh-1 mb-4">Enter a new age of dining</h2>
                        <p class="lead fw-normal text-muted mb-5 mb-lg-0">Our service is perfect for making peoples' lives convenient and be worry-free when they want to dine in restaurants</p>
                    </div>
                    <div class="col-sm-8 col-md-6">
                        <div class="px-5 px-sm-0">
                            <img class="img-fluid rounded-circle" src="/Imgs/Nav/restaurantcustomers.png" alt="..." style="width: 700px;"/>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- Call to action section-->
        <section class="cta">
            <div class="cta-content">
                <div class="container px-5">
                    <h2 class="display-1 lh-1 mb-4" style="color: white;">Join the CrowdFeed Fam<br />today!</h2>
                    <a class="btn btn-outline-light py-3 px-4 rounded-pill" href="https://startbootstrap.com/theme/new-age" target="_blank">What are you waiting for?</a>
                </div>
            </div>
        </section>
        <!-- App badge section-->
        <section class="bg-gradient-primary-to-secondary" id="download">
            <div class="container px-5">
                <h2 class="text-center text-white font-alt mb-4">Have any questions?</h2>
                <div class="d-flex flex-column flex-lg-row align-items-center justify-content-center">
                    <p class="lead fw-normal text-muted mb-5">Contact us via these platforms</p>
                </div>
            </div>
        </section>
        <!-- Footer-->
        <footer class="bg-black text-center py-5">
            <div class="container px-5">
                <div class="text-white-50 small">
                    <div class="mb-2">&copy; Your Website 2022. All Rights Reserved.</div>
                    <a href="#!">Privacy</a>
                    <span class="mx-1">&middot;</span>
                    <a href="#!">Terms</a>
                    <span class="mx-1">&middot;</span>
                    <a href="#!">FAQ</a>
                </div>
            </div>
        </footer>

        <!-- Swiper JS -->
        <script src="https://cdn.jsdelivr.net/npm/swiper/swiper-bundle.min.js"></script>

        <!-- Initialize Swiper -->
        <script>
            var swiper = new Swiper(".mySwiper", {
                slidesPerView: 1,
                spaceBetween: 30,
                loop: true,
                pagination: {
                    el: ".swiper-pagination",
                    clickable: true,
                },
                navigation: {
                    nextEl: ".swiper-button-next",
                    prevEl: ".swiper-button-prev",
                },
            });
        </script>
    </body>
    </html>
</asp:Content>