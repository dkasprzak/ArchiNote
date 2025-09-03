import {
  Box,
  Drawer,
  InboxIcon,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  MailIcon,
  Toolbar,
} from "../../assets/theme/components";
import { themeCommon } from "../../assets/theme/theme";

const drawerWidth = themeCommon.drawerWidth;

export const SideBar = ({
  open,
  onToggle,
}: {
  open: boolean;
  onToggle: () => void;
}) => {
  return (
    <>
      <Drawer
        variant="temporary"
        open={open}
        onClose={onToggle}
        ModalProps={{
          keepMounted: true,
          BackdropProps: {
            sx: {
              backgroundColor: "transparent",
            },
          },
        }}
        sx={{
          width: drawerWidth,
          flexShrink: 0,
          [`& .MuiDrawer-paper`]: {
            width: drawerWidth,
            boxSizing: "border-box",
            transition: "transform 0.3s cubic-bezier(0.25, 0.46, 0.45, 0.94)",
          },
        }}
      >
        <Toolbar />
        <Box sx={{ overflow: "auto" }}>
          <List>
            {["Inbox", "Starred", "Send email", "Drafts"].map((text, index) => (
              <ListItem key={text} disablePadding>
                <ListItemButton>
                  <ListItemIcon>
                    {index % 2 === 0 ? <InboxIcon /> : <MailIcon />}
                  </ListItemIcon>
                  <ListItemText primary={text} />
                </ListItemButton>
              </ListItem>
            ))}
          </List>
        </Box>
      </Drawer>
    </>
  );
};
