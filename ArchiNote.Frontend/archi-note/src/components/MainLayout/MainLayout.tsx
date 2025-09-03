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
          p: 3,
          mt: 8,
          transition: "padding 0.3s ease-in-out",
        }}
      >
        {children}
      </Box>
    </Box>
  );
};
