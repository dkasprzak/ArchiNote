import type { UUID } from "../../types/common.types";

export const ProjectStatus = {
  Pending: 0,
  InProgress: 1,
  Completed: 2,
  Cancelled: 3,
} as const;

export type ProjectStatus = (typeof ProjectStatus)[keyof typeof ProjectStatus];

export const PROJECT_STATUS_LABELS: Record<ProjectStatus, string> = {
  [ProjectStatus.Pending]: "Pending",
  [ProjectStatus.InProgress]: "In Progress",
  [ProjectStatus.Completed]: "Completed",
  [ProjectStatus.Cancelled]: "Cancelled",
};

export interface Project {
  id: UUID;
  name: string;
  status: ProjectStatus;
  createdDate: string;
  modifiedDate: string;
}

export interface CreateProjectRequest {
  name: string;
}

export interface CreateProjectRequest {
  projectId: UUID;
}

export const getStatusColor = (
  status: ProjectStatus
): "default" | "primary" | "secondary" | "success" | "error" => {
  switch (status) {
    case ProjectStatus.Pending:
      return "default";
    case ProjectStatus.InProgress:
      return "primary";
    case ProjectStatus.Completed:
      return "success";
    case ProjectStatus.Cancelled:
      return "error";
    default:
      return "default";
  }
};
