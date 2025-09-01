import { API_URL } from "../../constants/api";

export const projectService = {
  async getProjects() {
    try {
      const response = await fetch(`${API_URL}/projects`);

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      return await response.json();
    } catch (error) {
      console.error("Error fetching projects:", error);
    }
  },
};
