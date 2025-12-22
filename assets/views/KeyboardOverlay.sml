    <lane orientation="Vertical" layout="stretch" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
        <lane orientation="Vertical">
            <label text="HotKey Viewer" font="dialogue" horizontal-alignment="Middle" color="#FFFFFF" />
            
            <frame background={@Mods/StardewUI/Sprites/MenuBackground} padding="32,16,32,24" border={@Mods/StardewUI/Sprites/MenuBorder} border-thickness="36, 36, 40, 36">
                <lane orientation="Horizontal" horizontal-content-alignment="Middle" margin="0">
                
                <!-- MAIN BLOCK -->
                <lane orientation="Vertical" margin="0, 0, 20, 0">
                    <!-- Function Row -->
                    <lane margin="0,0,0,10">
                        <lane *repeat={:FunctionRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                        </lane>
                    </lane>
                    
                    <!-- Number Row -->
                    <lane>
                         <lane *repeat={:NumberRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                        </lane>
                    </lane>

                    <!-- Top Row -->
                    <lane>
                         <lane *repeat={:TopRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                        </lane>
                    </lane>

                     <!-- Home Row -->
                     <lane>
                         <lane *repeat={:HomeRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                        </lane>
                    </lane>
                    
                     <!-- Bottom Row -->
                     <lane>
                         <lane *repeat={:BottomRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                        </lane>
                    </lane>

                     <!-- Space Row -->
                     <lane>
                         <lane *repeat={:SpaceRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                        </lane>
                    </lane>
                </lane>

                <!-- NAVIGATION BLOCK -->
                <lane orientation="Vertical" margin="0, 0, 20, 0">
                     <!-- System Row (PrtScn) -->
                    <lane margin="0,0,0,10">
                        <lane *repeat={:SystemRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                        </lane>
                    </lane>
                    
                    <!-- Nav Block 1 (Ins) -->
                    <lane>
                        <lane *repeat={:NavRow1} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                        </lane>
                    </lane>
                     <!-- Nav Block 2 (Del) -->
                    <lane>
                        <lane *repeat={:NavRow2} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                        </lane>
                    </lane>
                    
                    <!-- Arrow Up -->
                    <lane margin="68, 20, 0, 0">
                        <lane *repeat={:ArrowUpRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                        </lane>
                    </lane>
                     <!-- Arrow Bottom -->
                    <lane>
                        <lane *repeat={:ArrowBottomRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                        </lane>
                    </lane>
                </lane>

                <!-- NUMPAD BLOCK -->
                <lane orientation="Horizontal">
                     <!-- Left Section (Rows) -->
                    <lane orientation="Vertical" margin="0, 0, 4, 0">
                         <!-- Numpad Row 1 -->
                        <lane>
                            <lane *repeat={:NumpadLeft1} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                                 <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                            </lane>
                        </lane>
                         <!-- Numpad Row 2 -->
                        <lane>
                            <lane *repeat={:NumpadLeft2} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                                 <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                            </lane>
                        </lane>
                         <!-- Numpad Row 3 -->
                        <lane>
                            <lane *repeat={:NumpadLeft3} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                                 <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                            </lane>
                        </lane>
                         <!-- Numpad Row 4 -->
                        <lane>
                            <lane *repeat={:NumpadLeft4} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                                 <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                            </lane>
                        </lane>
                         <!-- Numpad Row 5 -->
                        <lane>
                            <lane *repeat={:NumpadLeft5} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                                 <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                            </lane>
                        </lane>
                    </lane>

                    <!-- Right Section (Ops Column) -->
                    <lane orientation="Vertical">
                        <lane *repeat={:NumpadRight} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="4" horizontal-content-alignment="Middle" vertical-content-alignment="Middle" focusable="true" left-click=|OnKeyClick(^Key)|>
                                <lane orientation="Vertical" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                    <label text={:Label} font="small" scale="0.7" color="#FFFFFF" />
                                    <label text={:FaceText} color="#FFFFFF" font="dialogue" />
                                </lane>
                             </frame>
                        </lane>
                    </lane>
                </lane>
            </lane>
            </frame>
            
            <!-- Edit Popup (shown when IsEditing is true) -->
            <panel *if={IsEditing} layout="stretch" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                <frame background={@Mods/StardewUI/Sprites/MenuBackground} padding="24" border={@Mods/StardewUI/Sprites/MenuBorder} border-thickness="36, 36, 40, 36">
                    <lane orientation="Vertical" horizontal-content-alignment="Middle">
                        <label text="Change text:" font="dialogue" color="#553311" margin="0, 0, 0, 16" />
                        <label text={EditingKeyName} font="small" color="#666666" margin="0, 0, 0, 8" />
                        <textinput layout="300px 54px" text={<>EditText} margin="0, 0, 0, 16" />
                        <lane horizontal-content-alignment="Middle">
                            <button text="Cancel" left-click=|OnCancelEdit()| margin="0, 0, 16, 0" />
                            <button text="Confirm" left-click=|OnConfirmEdit()| />
                        </lane>
                    </lane>
                </frame>
            </panel>
        </lane>
    </lane>
