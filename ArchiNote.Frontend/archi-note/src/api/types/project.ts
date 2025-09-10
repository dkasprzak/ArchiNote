import type { UUID } from "../../types/common.types";

export const ProjectStatus = {
  Pending: 0,
  InProgress: 1,
  Completed: 2,
  Cancelled: 3,
} as const; //type safety

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
  createdDate: Date;
  modifiedDate: Date;
}

export interface CreateProjectRequest {
  name: string;
}

export interface DeleteProjectRequest {
  projectId: UUID;
}
