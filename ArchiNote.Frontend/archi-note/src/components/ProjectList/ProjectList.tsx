import { useEffect, useState } from "react";
import {
  PROJECT_STATUS_LABELS,
  type Project,
  getStatusColor,
} from "../../api/types/projects";
import { projectService } from "../../api/services/projectService";
import { Grid, Card, CardContent, Typography, Box, Chip } from "@mui/material";

export const ProjectList = () => {
  const [projects, setProjects] = useState<Project[] | null>(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      await new Promise((resolve) => setTimeout(resolve, 2000));
      const projectsList = await projectService.getProjects();
      setProjects(projectsList);
      setLoading(false);
    };

    fetchData();
  }, []);

  return (
    <>
      {
        <Grid container spacing={2}>
          {projects?.map((project) => (
            <Grid item xs={12} sm={6} md={4} lg={3} xl={2} key={project.id}>
              <Card>
                <CardContent>
                  <Box
                    display="flex"
                    //justifyContent="space-between"
                    alignItems="center"
                  >
                    <Typography variant="h6">{project.name}</Typography>
                    <Chip
                      label={PROJECT_STATUS_LABELS[project.status]}
                      color={getStatusColor(project.status)}
                      size="small"
                    />
                  </Box>
                </CardContent>
              </Card>
            </Grid>
          ))}
        </Grid>
      }
    </>
  );
};
