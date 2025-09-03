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

export const darkTheme = createTheme({
  palette: {
    mode: "dark",
  },
});
