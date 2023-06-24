import { Outlet } from "react-router-dom";
import "./index.scss";
function Home() {
  return (
    <div>
      <head>
        <meta charset="utf-8" />
        <meta
          name="viewport"
          content="width=device-width, initial-scale=1, shrink-to-fit=no"
        />
        <meta name="description" content="" />
        <meta name="author" content="Deloria" />
        <title>Creative - Start Bootstrap Theme</title>

        <link
          href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css"
          rel="stylesheet"
        />

        <link
          href="https://fonts.googleapis.com/css?family=Merriweather+Sans:400,700"
          rel="stylesheet"
        />
        <link
          href="https://fonts.googleapis.com/css?family=Merriweather:400,300,300italic,400italic,700,700italic"
          rel="stylesheet"
          type="text/css"
        />

        <link
          href="https://cdnjs.cloudflare.com/ajax/libs/SimpleLightbox/2.1.0/simpleLightbox.min.css"
          rel="stylesheet"
        />

        <link href="css/styles.css" rel="stylesheet" />
      </head>
      <body id="page-top">
        <nav
          class="navbar navbar-expand-lg fixed-top py-3"
          id="mainNav"
        >
          <div class="container px-4 px-lg-5">
            <a class="navbar-brand" href="/">
              Travel Notes
            </a>
            <div class="collapse navbar-collapse" id="navbarResponsive">
              <ul class="navbar-nav ms-auto my-2 my-lg-0">
                <li class="nav-item">
                  <a class="nav-link" href="/">
                    Home
                  </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#contact">
                    My Notes
                  </a>
                </li>
              </ul>
            </div>
          </div>
        </nav>
        <Outlet></Outlet>
        <footer class="bg-light py-5">
          <div class="container px-4 px-lg-5">
            <div class="small text-center text-muted">
              Copyright &copy; 2023 - Deloria
            </div>
          </div>
        </footer>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/SimpleLightbox/2.1.0/simpleLightbox.min.js"></script>
        <script src="https://cdn.startbootstrap.com/sb-forms-latest.js"></script>
      </body>
    </div>
  );
}

export default Home;
