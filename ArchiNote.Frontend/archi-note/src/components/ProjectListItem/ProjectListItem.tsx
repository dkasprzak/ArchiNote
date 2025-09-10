import { PROJECT_STATUS_LABELS, type Project } from "../../api/types/project";
import {
  Box,
  Card,
  CardContent,
  Chip,
  Stack,
  Typography,
} from "../../assets/theme/components";
import { getStatusChipStyle } from "../../styles/project.styles";
import { formatDateAuto } from "../../utils/date";

export const ProjectListItem = ({
  project,
  isSelected,
  onClick,
}: {
  project: Project;
  isSelected: boolean;
  onClick: (project: Project) => void;
}) => (
  <Card
    onClick={() => onClick(project)}
    sx={{
      mb: 1,
      cursor: "pointer",
      transition: "all 0.2s ease",
      border: isSelected ? 2 : 1,
      borderColor: isSelected ? "primary.main" : "divider",
      backgroundColor: isSelected ? "action.selected" : "background.paper",
      "&:hover": {
        backgroundColor: "action.hover",
        boxShadow: 2,
        transform: "translateY(-1px)",
      },
    }}
  >
    <CardContent sx={{ py: 1.5, px: 1.5 }}>
      <Stack
        direction="row"
        justifyContent="space-between"
        alignItems="center"
        spacing={2}
      >
        <Box sx={{ minWidth: 0, flex: 1 }}>
          <Typography
            variant="h6"
            component="div"
            sx={{
              fontWeight: 600,
              fontSize: "1rem",
              overflow: "hidden",
              textOverflow: "ellipsis",
              whiteSpace: "nowrap",
            }}
          >
            {project.name}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            Created: {formatDateAuto(project.createdDate)}
          </Typography>
        </Box>
        <Chip
          label={PROJECT_STATUS_LABELS[project.status]}
          size="small"
          sx={getStatusChipStyle(project.status)}
        />
      </Stack>
    </CardContent>
  </Card>
);
