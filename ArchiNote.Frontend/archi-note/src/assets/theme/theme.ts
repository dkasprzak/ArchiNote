import { createTheme } from "@mui/material/styles";

export const themeCommon = {
  fontSize: {
    xs: "12px",
    sm: "14px",
    md: "16px",
    lg: "20px",
    xl: "24px",
  } as const,
  drawerWidth: 240 as const,
};

export const sidebarColors = {
  dark: {
    selected: {
      background: "linear-gradient(135deg, #667eea 0%, #764ba2 100%)",
      backgroundHover: "linear-gradient(135deg, #5a67d8 0%, #6b46c1 100%)",
      color: "#ffffff",
      iconColor: "#ffffff",
      shadow: "0 4px 12px rgba(102, 126, 234, 0.3)",
    },
    hover: {
      backgroundColor: "rgba(255, 255, 255, 0.08)",
    },
    default: {
      color: "rgba(255, 255, 255, 0.87)",
      iconColor: "rgba(255, 255, 255, 0.6)",
      backgroundColor: "#1a1a1a",
      borderColor: "rgba(255, 255, 255, 0.12)",
    },
  },
  light: {
    selected: {
      background: "linear-gradient(135deg, #667eea 0%, #764ba2 100%)",
      backgroundHover: "linear-gradient(135deg, #5a67d8 0%, #6b46c1 100%)",
      color: "#ffffff",
      iconColor: "#ffffff",
      shadow: "0 4px 12px rgba(102, 126, 234, 0.2)",
    },
    hover: {
      backgroundColor: "rgba(0, 0, 0, 0.04)",
    },
    default: {
      color: "rgba(0, 0, 0, 0.87)",
      iconColor: "rgba(0, 0, 0, 0.54)",
      backgroundColor: "#ffffff",
      borderColor: "rgba(0, 0, 0, 0.12)",
    },
  },
} as const;

export const darkTheme = createTheme({
  palette: {
    mode: "dark",
  },
});
