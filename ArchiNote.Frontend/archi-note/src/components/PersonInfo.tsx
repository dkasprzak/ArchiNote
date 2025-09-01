import { useState } from "react";
import { Tel } from "./Tel";
import type { UUID } from "../types/common.types";
import "./PersonInfo.css";

export const PersonInfo = (props: {
  id: UUID;
  personName: string;
  personCity?: string;
  personTel: number;
  onDelete: (id: UUID) => void;
}) => {
  const [isExpanded, setIsExpanded] = useState(false);
  const handleBtnClick = () => {
    setIsExpanded(!isExpanded);
  };

  const handleBtnDeleteClick = () => {
    props.onDelete(props.id);
  };

  const buttonEl = (
    <button onClick={handleBtnClick}>{isExpanded ? "Hide" : "Show"}</button>
  );

  const buttonDelete = <button onClick={handleBtnDeleteClick}>Delete</button>;

  return (
    <li className={isExpanded ? "active" : ""}>
      <h2>{props.personName}</h2>
      {buttonEl}
      {buttonDelete}
      {isExpanded && (
        <>
          {props.personCity && <h3>Miasto: {props.personCity}</h3>}
          <h4>
            Tel: <Tel tel={props.personTel} />
          </h4>
        </>
      )}
    </li>
  );
};
