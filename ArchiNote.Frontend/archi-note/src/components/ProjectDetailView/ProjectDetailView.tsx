import { PROJECT_STATUS_LABELS, type Project } from "../../api/types/project";
import {
  ArrowBackIcon,
  Box,
  Button,
  CalendarIcon,
  Chip,
  CloseIcon,
  Divider,
  IconButton,
  Paper,
  Stack,
  Typography,
  WorkIcon,
} from "../../assets/theme/components";
import {
  getStatusChipStyle,
  getStatusColor,
} from "../../styles/project.styles";
import { formatDateAuto } from "../../utils/date";
import { SimpleInfoBox } from "../SimpleInfoBox/SimpleInfoBox";

export const ProjectDetailView = ({
  project,
  onClose,
  isMobile,
}: {
  project: Project;
  onClose: () => void;
  isMobile: boolean;
}) => {
  if (!project) {
    if (isMobile) {
      return null;
    }
    return (
      <SimpleInfoBox
        info="Select a project to view details"
        details="Choose from the list to see project information"
      />
    );
  }

  const detailContent = (
    <Box sx={{ p: 3 }}>
      {/* Header Section */}
      <Box sx={{ mb: 4 }}>
        <Stack
          direction="row"
          justifyContent="space-between"
          alignItems="flex-start"
          sx={{ mb: 2 }}
        >
          <Typography
            variant="h4"
            component="h1"
            sx={{ fontWeight: 700, color: "text.primary" }}
          >
            {project.name}
          </Typography>
          {!isMobile && (
            <IconButton
              onClick={onClose}
              sx={{
                color: "text.secondary",
                "&:hover": { backgroundColor: "action.hover" },
              }}
            >
              <CloseIcon />
            </IconButton>
          )}
        </Stack>
      </Box>

      <Divider sx={{ mb: 4 }} />

      {/* Project Information */}
      <Stack spacing={4}>
        {/* Basic Info */}
        <Paper
          elevation={0}
          sx={{
            p: 3,
            backgroundColor: "background.default",
            borderRadius: 2,
            border: "1px solid",
            borderColor: "divider",
          }}
        >
          <Typography
            variant="h6"
            sx={{ mb: 2, fontWeight: 600, color: "text.primary" }}
          >
            Project Information
          </Typography>

          <Stack spacing={3}>
            <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
              <WorkIcon sx={{ color: getStatusColor(project.status) }} />
              <Box>
                <Typography variant="body2" color="text.secondary">
                  Project ID
                </Typography>
                <Typography variant="body1" sx={{ fontWeight: 500 }}>
                  {project.id}
                </Typography>
              </Box>
            </Box>

            <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
              <CalendarIcon sx={{ color: getStatusColor(project.status) }} />
              <Box>
                <Typography variant="body2" color="text.secondary">
                  Created Date
                </Typography>
                <Typography variant="body1" sx={{ fontWeight: 500 }}>
                  {formatDateAuto(project.createdDate)}
                </Typography>
              </Box>
            </Box>
          </Stack>
        </Paper>

        {/* Status Details */}
        <Paper
          elevation={0}
          sx={{
            p: 3,
            backgroundColor: "background.default",
            borderRadius: 2,
            border: "1px solid",
            borderColor: "divider",
          }}
        >
          <Typography
            variant="h6"
            sx={{ mb: 2, fontWeight: 600, color: "text.primary" }}
          >
            Status Information
          </Typography>

          <Box>
            <Stack direction="row" spacing={2} alignItems="center">
              <Chip
                label={PROJECT_STATUS_LABELS[project.status]}
                size="medium"
                sx={getStatusChipStyle(project.status)}
              />
              <Typography variant="body2" color="text.secondary">
                Last updated: {formatDateAuto(project.modifiedDate)}
              </Typography>
            </Stack>
          </Box>
        </Paper>

        {/* Action Buttons */}
        <Paper
          elevation={0}
          sx={{
            p: 3,
            backgroundColor: "background.default",
            borderRadius: 2,
            border: "1px solid",
            borderColor: "divider",
          }}
        >
          <Typography
            variant="h6"
            sx={{ mb: 2, fontWeight: 600, color: "text.primary" }}
          >
            Actions
          </Typography>

          <Stack direction="row" spacing={2} flexWrap="wrap">
            <Button
              variant="contained"
              color="primary"
              sx={{ borderRadius: 2 }}
            >
              Edit Project
            </Button>
            <Button variant="outlined" color="primary" sx={{ borderRadius: 2 }}>
              View History
            </Button>
            <Button
              variant="outlined"
              color="secondary"
              sx={{ borderRadius: 2 }}
            >
              Export Data
            </Button>
          </Stack>
        </Paper>
      </Stack>
    </Box>
  );

  // Mobile: Full screen drawer
  if (isMobile) {
    return (
      <Box
        sx={{
          position: "fixed",
          top: 64,
          left: 0,
          right: 0,
          bottom: 0,
          backgroundColor: "background.default",
          zIndex: 1200, // niższy niż AppBar (1300)
          overflow: "auto",
        }}
      >
        <Box sx={{ p: 2 }}>
          <Button
            startIcon={<ArrowBackIcon />}
            onClick={onClose}
            variant="outlined"
            size="small"
            sx={{ mb: 2 }}
          >
            Back to Projects
          </Button>
          {detailContent}
        </Box>
      </Box>
    );
  }

  return <Box sx={{ flex: 1, overflow: "auto" }}>{detailContent}</Box>;
};
