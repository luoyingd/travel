import Services from "./service";
import Category from "./category";
import { myToken } from "../../utils/auth";
function Main() {
  return (
    <div>
      <header class="masthead">
        <div class="container px-4 px-lg-5 h-100">
          <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center text-center">
            <div class="col-lg-8 align-self-end">
              <h1 class="text-white font-weight-bold">
                Start Your Amazing Travel
              </h1>
              <hr class="divider" />
            </div>
            <div class="col-lg-8 align-self-baseline">
              <p class="text-white-75 mb-5">
                Travel Notes can help you browse travel notes from all over the
                world. Start your free journey now!
              </p>

              {myToken.getToken() ? null : (
                <div>
                  <a class="btn btn-primary btn-xl" href="/login">
                    Sign In By Email
                  </a>
                  <p></p>
                  <a class="btn btn-primary btn-xl" href="#services">
                    Sign In By Google
                  </a>
                </div>
              )}
            </div>
          </div>
        </div>
      </header>
      <section class="page-section" id="services">
        <Services></Services>
      </section>
      <div id="portfolio">
        <Category></Category>
      </div>
    </div>
  );
}

export default Main;
