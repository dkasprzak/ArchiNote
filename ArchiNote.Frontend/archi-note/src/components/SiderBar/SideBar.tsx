import { useNavigate, useLocation } from "react-router-dom";
import {
  Box,
  Drawer,
  HomeWorkIcon,
  InboxIcon,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  MailIcon,
  Toolbar,
} from "../../assets/theme/components";
import { sidebarColors, themeCommon } from "../../assets/theme/theme";

const drawerWidth = themeCommon.drawerWidth;

const menuItems = [
  { text: "Projekty", path: "/", icon: <HomeWorkIcon /> },
  { text: "Test", path: "/projects", icon: <InboxIcon /> },
  { text: "Test1", path: "/projects1", icon: <MailIcon /> },
  { text: "Test2", path: "/projects2", icon: <InboxIcon /> },
];

export const SideBar = ({
  open,
  onToggle,
}: {
  open: boolean;
  onToggle: () => void;
}) => {
  const navigate = useNavigate();
  const location = useLocation();

  const colors = sidebarColors.dark;

  return (
    <Drawer
      variant="temporary"
      open={open}
      onClose={onToggle}
      ModalProps={{ keepMounted: true, BackdropProps: { invisible: true } }}
      sx={{
        [`& .MuiDrawer-paper`]: {
          width: drawerWidth,
          boxSizing: "border-box",
          backgroundColor: colors.default.backgroundColor,
          borderRight: `1px solid ${colors.default.borderColor}`,
        },
      }}
    >
      <Toolbar />
      <Box sx={{ overflow: "auto" }}>
        <List sx={{ px: 1 }}>
          {menuItems.map((item) => (
            <ListItem key={item.path} disablePadding sx={{ mb: 0.5 }}>
              <ListItemButton
                selected={location.pathname === item.path}
                onClick={() => {
                  navigate(item.path);
                  onToggle();
                }}
                sx={{
                  borderRadius: 2,
                  color: colors.default.color,
                  "&:hover": {
                    backgroundColor: colors.hover.backgroundColor,
                  },
                  "&.Mui-selected": {
                    background: colors.selected.background,
                    color: colors.selected.color,
                    "&:hover": {
                      background: colors.selected.backgroundHover,
                      transform: "translateY(-1px)",
                      boxShadow: colors.selected.shadow,
                    },
                    "& .MuiListItemIcon-root": {
                      color: colors.selected.iconColor,
                    },
                  },
                }}
              >
                <ListItemIcon
                  sx={{
                    minWidth: 40,
                    color: colors.default.iconColor,
                  }}
                >
                  {item.icon}
                </ListItemIcon>
                <ListItemText
                  primary={item.text}
                  sx={{
                    "& .MuiListItemText-primary": {
                      fontWeight: 400,
                    },
                  }}
                />
              </ListItemButton>
            </ListItem>
          ))}
        </List>
      </Box>
    </Drawer>
  );
};
