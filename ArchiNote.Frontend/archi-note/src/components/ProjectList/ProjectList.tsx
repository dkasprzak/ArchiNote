import { useEffect, useState } from "react";
import { type Project } from "../../api/types/project";
import { projectService } from "../../api/services/projectService";
import { Loader } from "../Loader/Loader";
import {
  Box,
  Typography,
  useMediaQuery,
  useTheme,
} from "../../assets/theme/components";
import { ProjectDetailView } from "../ProjectDetailView/ProjectDetailView";
import { ProjectListItem } from "../ProjectListItem/ProjectListItem";
import { SimpleInfoBox } from "../SimpleInfoBox/SimpleInfoBox";

export const ProjectList = () => {
  const [projects, setProjects] = useState<Project[] | null>(null);
  const [loading, setLoading] = useState(false);
  const [selectedProject, setSelectedProject] = useState<Project | null>(null);

  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down("md"));

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      //await new Promise((resolve) => setTimeout(resolve, 1000));
      const projectsList = await projectService.getProjects();
      setProjects(projectsList);
      setLoading(false);
    };

    fetchData();
  }, []);

  const handleProjectSelect = (project: Project) => {
    setSelectedProject(project);
  };

  const handleCloseDetail = () => {
    setSelectedProject(null);
  };

  if (loading || !projects) {
    return <Loader show={loading} />;
  }

  if (projects.length === 0) {
    return <SimpleInfoBox info="No projects found" />;
  }

  // Mobile Layout
  if (isMobile) {
    return (
      <Box
        sx={{
          flexGrow: 1,
          width: "100%",
          overflow: "hidden", // zapobiega horizontal scroll
        }}
      >
        {!selectedProject ? (
          <Box
            sx={{
              p: 2,
              width: "100%",
              boxSizing: "border-box", // padding nie zwiększa szerokości
            }}
          >
            <Typography variant="h5" sx={{ mb: 3, fontWeight: 700 }}>
              Projects
            </Typography>
            {projects.map((project) => (
              <ProjectListItem
                key={project.id}
                project={project}
                isSelected={false}
                onClick={handleProjectSelect}
              />
            ))}
          </Box>
        ) : (
          <ProjectDetailView
            project={selectedProject}
            onClose={handleCloseDetail}
            isMobile={true}
          />
        )}
      </Box>
    );
  }

  // Desktop Layout
  return (
    <Box
      sx={{
        display: "flex",
        height: "calc(100vh - 64px - 48px)", // minus AppBar + padding
        minHeight: 0,
      }}
    >
      {/* Master Panel */}
      <Box
        sx={{
          width: 400,
          borderRight: 1,
          borderColor: "divider",
          backgroundColor: "background.paper",
          display: "flex",
          flexDirection: "column",
          minHeight: 0,
        }}
      >
        <Box
          sx={{
            p: 3,
            borderBottom: 1,
            borderColor: "divider",
            flexShrink: 0, // DODANE - nie pozwól header się kurczyć
          }}
        >
          <Typography
            variant="h5"
            sx={{ fontWeight: 700, color: "text.primary" }}
          >
            Projects
          </Typography>
          <Typography variant="body2" color="text.secondary" sx={{ mt: 0.5 }}>
            {projects.length} projects found
          </Typography>
        </Box>
        <Box
          sx={{
            flex: 1,
            overflow: "auto",
            p: 2,
            minHeight: 0,
          }}
        >
          {projects.map((project) => (
            <ProjectListItem
              key={project.id}
              project={project}
              isSelected={selectedProject?.id === project.id}
              onClick={handleProjectSelect}
            />
          ))}
        </Box>
      </Box>

      {/* Detail Panel */}
      <Box
        sx={{
          flex: 1,
          minHeight: 0, // DODANE
          display: "flex",
          flexDirection: "column",
        }}
      >
        <ProjectDetailView
          project={selectedProject!}
          onClose={handleCloseDetail}
          isMobile={false}
        />
      </Box>
    </Box>
  );
};
