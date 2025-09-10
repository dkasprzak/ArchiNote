import { ProjectStatus } from "../api/types/project";

export const statusColor = {
  default: {
    background: "#475569",
    text: "#f1f5f9",
  },
  [ProjectStatus.Pending]: {
    background: "#92400e",
    text: "#fef3c7",
  },
  [ProjectStatus.InProgress]: {
    background: "#1e40af",
    text: "#dbeafe",
  },
  [ProjectStatus.Completed]: {
    background: "#065f46",
    text: "#d1fae5",
  },
  [ProjectStatus.Cancelled]: {
    background: "#dc2626",
    text: "#fee2e2",
  },
} as const;

export const getStatusChipStyle = (status: ProjectStatus) => {
  const colors = statusColor[status] || statusColor.default;
  return {
    backgroundColor: colors.background,
    color: colors.text,
    fontWeight: 600,
    border: "none",
  };
};

export const getStatusColor = (status: ProjectStatus) => {
  switch (status) {
    case ProjectStatus.Pending:
      return statusColor[status].background;
    case ProjectStatus.InProgress:
      return statusColor[status].background;
    case ProjectStatus.Completed:
      return statusColor[status].background;
    case ProjectStatus.Cancelled:
      return statusColor[status].background;
    default:
      return statusColor.default.background;
  }
};
