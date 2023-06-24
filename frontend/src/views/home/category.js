import nature from "../../assets/img/category/nature.png";
import city from "../../assets/img/category/city.jpeg";
import entertainment from "../../assets/img/category/entertainment.jpeg";
import meseum from "../../assets/img/category/meseum.webp";
import shopping from "../../assets/img/category/shopping.jpeg";
import adventure from "../../assets/img/category/adventure.webp";
function Category() {
  return (
    <div class="container-fluid p-0">
      <div class="row g-0">
        <div class="col-lg-4 col-sm-6">
          <a
            class="portfolio-box"
            // TODO: 做成路由
            href="../../assets/img/portfolio/fullsize/1.jpg"
            title="Project Name"
          >
            <img class="img-fluid" src={meseum} alt="..." />
            <div class="portfolio-box-caption">
              <div class="project-name">Meseum</div>
            </div>
          </a>
        </div>
        <div class="col-lg-4 col-sm-6">
          <a
            class="portfolio-box"
            href="../../assets/img/portfolio/fullsize/2.jpg"
            title="Project Name"
          >
            <img class="img-fluid" src={city} alt="..." />
            <div class="portfolio-box-caption">
              <div class="project-name">City</div>
            </div>
          </a>
        </div>
        <div class="col-lg-4 col-sm-6">
          <a
            class="portfolio-box"
            href="../../assets/img/portfolio/fullsize/3.jpg"
            title="Project Name"
          >
            <img class="img-fluid" src={shopping} alt="..." />
            <div class="portfolio-box-caption">
              <div class="project-name">Shopping</div>
            </div>
          </a>
        </div>
        <div class="col-lg-4 col-sm-6">
          <a
            class="portfolio-box"
            href="../../assets/img/portfolio/fullsize/4.jpg"
            title="Project Name"
          >
            <img class="img-fluid" src={adventure} alt="..." />
            <div class="portfolio-box-caption">
              <div class="project-name">Adventure</div>
            </div>
          </a>
        </div>
        <div class="col-lg-4 col-sm-6">
          <a class="portfolio-box" href="" title="Nature">
            <img class="img-fluid" src={entertainment} alt="..." />
            <div class="portfolio-box-caption">
              <div class="project-name">Entertainment</div>
            </div>
          </a>
        </div>
        <div class="col-lg-4 col-sm-6">
          <a
            class="portfolio-box"
            href="../../assets/img/portfolio/fullsize/6.jpg"
            title="Project Name"
          >
            <img class="img-fluid" src={nature} alt="..." />
            <div class="portfolio-box-caption p-3">
              <div class="project-name">Nature</div>
            </div>
          </a>
        </div>
      </div>
    </div>
  );
}

export default Category;
