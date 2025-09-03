import { Routes, Route } from "react-router-dom";
import { MainLayout } from "../components/MainLayout/MainLayout";
import { ProjectList } from "../components/ProjectList/ProjectList";

export const AppRouter = () => (
  <MainLayout>
    <Routes>
      <Route path="/" element={<ProjectList />} />
    </Routes>
  </MainLayout>
);

//   <Route path="/projects" element={<ProjectsPage />} />
//   <Route path="/projects/:id" element={<ProjectDetails />} />
//   <Route path="/settings" element={<SettingsPage />} />
