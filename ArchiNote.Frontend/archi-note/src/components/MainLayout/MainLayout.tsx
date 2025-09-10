import { useState, type ReactNode } from "react";
import {
  Box,
  AppBar,
  Toolbar,
  IconButton,
  MenuIcon,
  Typography,
} from "../../assets/theme/components";
import { SideBar } from "../SiderBar/SideBar";

export const MainLayout = ({ children }: { children: ReactNode }) => {
  const [sidebarOpen, setSidebarOpen] = useState(false);

  const handleSidebarToggle = () => {
    setSidebarOpen(!sidebarOpen);
  };

  return (
    <Box sx={{ display: "flex" }}>
      <AppBar
        position="fixed"
        sx={{ zIndex: (theme) => theme.zIndex.drawer + 1 }}
      >
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            onClick={handleSidebarToggle}
            sx={{ mr: 2 }}
          >
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            ArchiNote
          </Typography>
        </Toolbar>
      </AppBar>
      <SideBar open={sidebarOpen} onToggle={handleSidebarToggle} />
      <Box
        component="main"
        sx={{
          flexGrow: 1,
          p: { xs: 0, sm: 3 }, // ZERO padding na mobile
          mt: 8,
          transition: "padding 0.3s ease-in-out",
          width: "100vw", // pełna szerokość viewport
          maxWidth: "100vw", // nie więcej niż viewport
          overflow: "hidden", // obetnij wszystko co wychodzi
          boxSizing: "border-box",
        }}
      >
        {children}
      </Box>
    </Box>
  );
};
