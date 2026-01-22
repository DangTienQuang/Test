import React, { useState } from "react";
import {
  Stage,
  Layer,
  Rect,
  Image as KonvaImage,
  Group,
  Text,
} from "react-konva";
import useImage from "use-image";
import { useDispatch, useSelector } from "react-redux";
import {
  addAnnotation,
  removeAnnotation,
} from "../../../store/annotator/labelling/labelingSlice";

const LabelingWorkspace = ({ imageUrl }) => {
  const [image, status] = useImage(imageUrl, "anonymous");
  const dispatch = useDispatch();

  const { annotations, selectedLabel } = useSelector(
    (state) => state.labeling || { annotations: [] },
  );
  const [newRect, setNewRect] = useState(null);

  if (status === "loading") return <div className="text-white">Loading...</div>;

  const handleMouseDown = (e) => {
    if (!selectedLabel) return;
    const pos = e.target.getStage().getPointerPosition();
    setNewRect({
      x: pos.x,
      y: pos.y,
      width: 0,
      height: 0,
      id: Date.now().toString(),
    });
  };

  const handleMouseMove = (e) => {
    if (!newRect) return;
    const pos = e.target.getStage().getPointerPosition();
    setNewRect({
      ...newRect,
      width: pos.x - newRect.x,
      height: pos.y - newRect.y,
    });
  };

  const handleMouseUp = () => {
    if (newRect && Math.abs(newRect.width) > 5) {
      dispatch(
        addAnnotation({
          ...newRect,
          labelId: selectedLabel.id,
          color: selectedLabel.color,
          isAi: false,
        }),
      );
    }
    setNewRect(null);
  };

  return (
    <div className="bg-dark rounded overflow-hidden d-flex justify-content-center shadow-lg border border-secondary">
      <Stage
        width={800}
        height={600}
        onMouseDown={handleMouseDown}
        onMouseMove={handleMouseMove}
        onMouseUp={handleMouseUp}
        style={{ cursor: selectedLabel ? "crosshair" : "default" }}
      >
        <Layer>
          {image && <KonvaImage image={image} width={800} height={600} />}

          {annotations.map((ann) => (
            <Group key={ann.id}>
              <Rect
                x={ann.x}
                y={ann.y}
                width={ann.width}
                height={ann.height}
                stroke={ann.color}
                strokeWidth={2}
                onDblClick={() => dispatch(removeAnnotation(ann.id))}
              />
              <Rect
                x={ann.x}
                y={ann.y - 18}
                width={80}
                height={18}
                fill={ann.color}
              />
              <Text
                x={ann.x + 5}
                y={ann.y - 14}
                text={ann.labelName || "Label"}
                fontSize={11}
                fontStyle="bold"
                fill="white"
              />
            </Group>
          ))}

          {newRect && (
            <Rect {...newRect} stroke="yellow" strokeWidth={1} dash={[4, 4]} />
          )}
        </Layer>
      </Stage>
    </div>
  );
};

export default LabelingWorkspace;
