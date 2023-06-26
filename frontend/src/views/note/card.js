function NoteCard() {
  return (
    <div class="col mb-5">
      <div class="card h-100">
        <div
          class="badge bg-warning text-white position-absolute"
          style={{ top: 0.5, right: 0.5 }}
        >
          Hot
        </div>
        <img
          class="card-img-top"
          src="https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
          alt="..."
        />

        <div class="card-body p-4">
          <div class="text-center">
            澳洲的工作进展效率真的挺慢，继续焦急等待
          </div>
        </div>

        <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
          <div class="text-center">
            <a class="btn btn-outline-dark mt-auto" href="#">
              View more
            </a>
          </div>
        </div>
      </div>
    </div>
  );
}

export default NoteCard;
