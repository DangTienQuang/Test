import React from "react";
import { useSelector, useDispatch } from "react-redux";
import { setSelectedLabel } from "../../../store/annotator/labelling/labelingSlice";

const LabelPicker = () => {
  const dispatch = useDispatch();

  const { labels } = useSelector((state) => state.task);
  const { selectedLabel } = useSelector((state) => state.labeling);

  if (!labels || labels.length === 0) {
    return <div className="p-3 text-muted">Đang tải bộ nhãn...</div>;
  }
  return (
    <div className="card mt-3 shadow-sm">
      <div className="card-header bg-light border-bottom">
        <h6 className="card-title mb-0 text-primary fw-bold">
          <i className="ri-list-check-2 me-2"></i>BỘ NHÃN CHUẨN
        </h6>
      </div>
      <div className="card-body p-2">
        <div className="vstack gap-2">
          {labels.map((label) => {
            const isSelected = selectedLabel?.id === label.id;
            return (
              <button
                key={label.id}
                onClick={() => dispatch(setSelectedLabel(label))}
                className={`btn text-start d-flex justify-content-between align-items-center p-2 ${
                  isSelected ? "btn-dark shadow" : "btn-outline-secondary"
                }`}
                style={
                  isSelected ? { borderLeft: `5px solid ${label.color}` } : {}
                }
              >
                <div className="d-flex align-items-center">
                  <span
                    className="rounded-circle me-3"
                    style={{
                      width: "12px",
                      height: "12px",
                      backgroundColor: label.color,
                    }}
                  ></span>
                  <span className={isSelected ? "text-white" : "text-dark"}>
                    {label.name}
                  </span>
                </div>
              </button>
            );
          })}
        </div>
      </div>
      <div className="card-footer bg-light-subtle p-2">
        <small className="text-muted italic">
          * Chọn một nhãn phía trên để bắt đầu vẽ.
        </small>
      </div>
    </div>
  );
};

export default LabelPicker;
