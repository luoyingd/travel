import { Button } from "antd";
import { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";
import AddNote from "./add";
function Notes() {
  const [params] = useSearchParams();
  const id = params.get("id");
  const [openAdd, setOpenAdd] = useState(false);
  const [key, setKey] = useState(0);
  useEffect(() => {}, []);
  return (
    <div>
      <body>
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
          <div class="container px-4 px-lg-5">
            <a class="navbar-brand" href="/">
              Travel Notes
            </a>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
              <ul class="navbar-nav me-auto mb-2 mb-lg-0 ms-lg-4">
                <li class="nav-item">
                  {id ? (
                    <a class="nav-link active" aria-current="page" href="#!">
                      Logout
                    </a>
                  ) : null}
                </li>
              </ul>
              {id ? (
                <Button
                  className="btn-center btn-add"
                  size="large"
                  onClick={() => {
                    setOpenAdd(true);
                    setKey(key + 1);
                  }}
                >
                  Add New
                </Button>
              ) : null}
            </div>
          </div>
        </nav>

        <AddNote isOpen={openAdd} key={key}></AddNote>

        <header class="bg-dark py-5">
          <div class="container px-4 px-lg-5 my-5">
            <div class="text-center text-white">
              <h1 class="display-4 fw-bolder">Shop in style</h1>
              <p class="lead fw-normal text-white-50 mb-0">
                With this shop hompeage template
              </p>
            </div>
          </div>
        </header>

        <section class="py-5">
          <div class="container px-4 px-lg-5 mt-5">
            <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center">
              <div class="col mb-5">
                <div class="card h-100">
                  <img
                    class="card-img-top"
                    src="https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
                    alt="..."
                  />

                  <div class="card-body p-4">
                    <div class="text-center">
                      <h5 class="fw-bolder">Fancy Product</h5>
                      $40.00 - $80.00
                    </div>
                  </div>

                  <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                    <div class="text-center">
                      <a class="btn btn-outline-dark mt-auto" href="#">
                        View options
                      </a>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col mb-5">
                <div class="card h-100">
                  <div
                    class="badge bg-dark text-white position-absolute"
                    style={{ top: 0.5, right: 0.5 }}
                  >
                    Sale
                  </div>

                  <img
                    class="card-img-top"
                    src="https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
                    alt="..."
                  />

                  <div class="card-body p-4">
                    <div class="text-center">
                      <h5 class="fw-bolder">Special Item</h5>
                      <div class="d-flex justify-content-center small text-warning mb-2">
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                      </div>
                      <span class="text-muted text-decoration-line-through">
                        $20.00
                      </span>
                      $18.00
                    </div>
                  </div>

                  <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                    <div class="text-center">
                      <a class="btn btn-outline-dark mt-auto" href="#">
                        Add to cart
                      </a>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col mb-5">
                <div class="card h-100">
                  <div
                    class="badge bg-dark text-white position-absolute"
                    style={{ top: 0.5, right: 0.5 }}
                  >
                    Sale
                  </div>

                  <img
                    class="card-img-top"
                    src="https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
                    alt="..."
                  />

                  <div class="card-body p-4">
                    <div class="text-center">
                      <h5 class="fw-bolder">Sale Item</h5>
                      <span class="text-muted text-decoration-line-through">
                        $50.00
                      </span>
                      $25.00
                    </div>
                  </div>

                  <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                    <div class="text-center">
                      <a class="btn btn-outline-dark mt-auto" href="#">
                        Add to cart
                      </a>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col mb-5">
                <div class="card h-100">
                  <img
                    class="card-img-top"
                    src="https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
                    alt="..."
                  />

                  <div class="card-body p-4">
                    <div class="text-center">
                      <h5 class="fw-bolder">Popular Item</h5>
                      <div class="d-flex justify-content-center small text-warning mb-2">
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                      </div>
                      $40.00
                    </div>
                  </div>

                  <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                    <div class="text-center">
                      <a class="btn btn-outline-dark mt-auto" href="#">
                        Add to cart
                      </a>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col mb-5">
                <div class="card h-100">
                  <div
                    class="badge bg-dark text-white position-absolute"
                    style={{ top: 0.5, right: 0.5 }}
                  >
                    Sale
                  </div>

                  <img
                    class="card-img-top"
                    src="https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
                    alt="..."
                  />

                  <div class="card-body p-4">
                    <div class="text-center">
                      <h5 class="fw-bolder">Sale Item</h5>
                      <span class="text-muted text-decoration-line-through">
                        $50.00
                      </span>
                      $25.00
                    </div>
                  </div>

                  <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                    <div class="text-center">
                      <a class="btn btn-outline-dark mt-auto" href="#">
                        Add to cart
                      </a>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col mb-5">
                <div class="card h-100">
                  <img
                    class="card-img-top"
                    src="https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
                    alt="..."
                  />

                  <div class="card-body p-4">
                    <div class="text-center">
                      <h5 class="fw-bolder">Fancy Product</h5>
                      $120.00 - $280.00
                    </div>
                  </div>

                  <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                    <div class="text-center">
                      <a class="btn btn-outline-dark mt-auto" href="#">
                        View options
                      </a>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col mb-5">
                <div class="card h-100">
                  <div
                    class="badge bg-dark text-white position-absolute"
                    style={{ top: 0.5, right: 0.5 }}
                  >
                    Sale
                  </div>

                  <img
                    class="card-img-top"
                    src="https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
                    alt="..."
                  />

                  <div class="card-body p-4">
                    <div class="text-center">
                      <h5 class="fw-bolder">Special Item</h5>
                      <div class="d-flex justify-content-center small text-warning mb-2">
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                      </div>
                      <span class="text-muted text-decoration-line-through">
                        $20.00
                      </span>
                      $18.00
                    </div>
                  </div>

                  <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                    <div class="text-center">
                      <a class="btn btn-outline-dark mt-auto" href="#">
                        Add to cart
                      </a>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col mb-5">
                <div class="card h-100">
                  <img
                    class="card-img-top"
                    src="https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
                    alt="..."
                  />

                  <div class="card-body p-4">
                    <div class="text-center">
                      <h5 class="fw-bolder">Popular Item</h5>
                      <div class="d-flex justify-content-center small text-warning mb-2">
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                        <div class="bi-star-fill"></div>
                      </div>
                      $40.00
                    </div>
                  </div>

                  <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                    <div class="text-center">
                      <a class="btn btn-outline-dark mt-auto" href="#">
                        Add to cart
                      </a>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>

        <footer class="bg-light py-5">
          <div class="container px-4 px-lg-5">
            <div class="small text-center text-muted">
              Copyright &copy; 2023 - Deloria
            </div>
          </div>
        </footer>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>

        <script src="js/scripts.js"></script>
      </body>
    </div>
  );
}

export default Notes;
