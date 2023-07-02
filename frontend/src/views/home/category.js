import { categories } from "../../utils/constant";
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
            <img class="img-fluid" src={categories[0].src} alt="..." />
            <div class="portfolio-box-caption">
              <div class="project-name">{categories[0].name}</div>
            </div>
          </a>
        </div>
        <div class="col-lg-4 col-sm-6">
          <a
            class="portfolio-box"
            href="../../assets/img/portfolio/fullsize/2.jpg"
            title="Project Name"
          >
            <img class="img-fluid" src={categories[1].src} alt="..." />
            <div class="portfolio-box-caption">
              <div class="project-name">{categories[1].name}</div>
            </div>
          </a>
        </div>
        <div class="col-lg-4 col-sm-6">
          <a
            class="portfolio-box"
            href="../../assets/img/portfolio/fullsize/3.jpg"
            title="Project Name"
          >
            <img class="img-fluid" src={categories[2].src} alt="..." />
            <div class="portfolio-box-caption">
              <div class="project-name">{categories[2].name}</div>
            </div>
          </a>
        </div>
        <div class="col-lg-4 col-sm-6">
          <a
            class="portfolio-box"
            href="../../assets/img/portfolio/fullsize/4.jpg"
            title="Project Name"
          >
            <img class="img-fluid" src={categories[3].src} alt="..." />
            <div class="portfolio-box-caption">
              <div class="project-name">{categories[3].name}</div>
            </div>
          </a>
        </div>
        <div class="col-lg-4 col-sm-6">
          <a class="portfolio-box" href="" title="Nature">
            <img class="img-fluid" src={categories[4].src} alt="..." />
            <div class="portfolio-box-caption">
              <div class="project-name">{categories[4].name}</div>
            </div>
          </a>
        </div>
        <div class="col-lg-4 col-sm-6">
          <a
            class="portfolio-box"
            href="../../assets/img/portfolio/fullsize/6.jpg"
            title="Project Name"
          >
            <img class="img-fluid" src={categories[5].src} alt="..." />
            <div class="portfolio-box-caption p-3">
              <div class="project-name">{categories[5].name}</div>
            </div>
          </a>
        </div>
      </div>
    </div>
  );
}

export default Category;
